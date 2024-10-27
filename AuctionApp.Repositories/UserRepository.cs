using AuctionApp.DataLayer;
using AuctionApp.DataLayer.Models;
using AuctionApp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionContext _auctionContext;
        public UserRepository(AuctionContext auctionContext) 
        {
            _auctionContext = auctionContext;
        }
        public async Task<User> AuthenticateAsync(User user)
        {
            return await _auctionContext.Users
                         .Where(x => x.UserEmail == user.UserEmail).FirstOrDefaultAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            user.CreatedDate = DateTime.UtcNow;
            _auctionContext.Users.Add(user);
            await _auctionContext.SaveChangesAsync();

            return user;
        }
    }
}
