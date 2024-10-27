using AuctionApp.DataLayer.Dtos;
using AuctionApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserDto createDto)
        {
            var result = await _service.CreateServiceAsync(createDto);
            if (result != null)
                return Ok("User Created Successfully");
            else return BadRequest("Registration Failed");
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {
            var result = await _service.AuthenticateServiceAsync(dto);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }
    }
}
