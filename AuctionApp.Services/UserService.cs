using AuctionApp.DataLayer.Dtos;
using AuctionApp.DataLayer.Models;
using AuctionApp.Repositories.IRepositories;
using AuctionApp.Services.IServices;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuctionApp.Services
{
    public class UserService : IUserService
    {
   
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly string _key;
        private readonly string _issuer;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration) {
            _userRepository = userRepository;
            _mapper = mapper;
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
        }
        public async Task<UserDto> CreateServiceAsync(UserDto createEntity)
        {
            try
            {
                var mapResult = _mapper.Map<User>(createEntity);
                mapResult.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createEntity.Password);
                var result = await _userRepository.CreateAsync(mapResult);
                var resultDto = _mapper.Map<UserDto>(result);

                if (result == null)
                {
                    throw new Exception("Registration Failed.");
                }
                else
                {
                    return resultDto;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UserDto> AuthenticateServiceAsync(LoginDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.UserEmail))
                    throw new ArgumentNullException("Email is Empty.");
                if (string.IsNullOrEmpty(dto.Password))
                    throw new ArgumentNullException("Password is Empty.");

                var mapperResult = new User { UserEmail = dto.UserEmail };

                var result = await _userRepository.AuthenticateAsync(mapperResult);

                // check if username exists
                if (result == null || result.UserEmail != dto.UserEmail)
                {
                    throw new Exception("Invalid Email.");
                }

                // validate
                if (result == null || !BCrypt.Net.BCrypt.Verify(dto.Password, result.PasswordHash))
                    throw new Exception("Username or password is incorrect");

                var finalResult = _mapper.Map<UserDto>(result);

                finalResult.Token = GenerateToken(finalResult.Id, finalResult.UserName);

                return finalResult;
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string GenerateToken(int userId, string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("UserId", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
