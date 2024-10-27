using AuctionApp.DataLayer;
using AuctionApp.DataLayer.Models;
using AuctionApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repositories
{
    public class AuctionBidRepository : IAuctionBidRepository
    {
        private readonly AuctionContext _auctionContext;
        public AuctionBidRepository(AuctionContext auctionContext)
        {
            _auctionContext = auctionContext;

        }
        public async Task<AuctionBid> CreateAsync(AuctionBid createEntity)
        {
            createEntity.CreatedDate = DateTime.UtcNow;
            _auctionContext.AuctionBids.Add(createEntity);
            await _auctionContext.SaveChangesAsync();
            return createEntity;
        }
    }
}
