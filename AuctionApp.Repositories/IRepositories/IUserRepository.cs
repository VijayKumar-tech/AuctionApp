using AuctionApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> AuthenticateAsync(User user);
    }
}
