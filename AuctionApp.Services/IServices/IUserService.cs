using AuctionApp.DataLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Services.IServices
{
    public interface IUserService
    {
        Task<UserDto> CreateServiceAsync(UserDto createEntity);
        Task<UserDto> AuthenticateServiceAsync(LoginDto dto);

    }
}
