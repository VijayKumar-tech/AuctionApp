using AuctionApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repositories.IRepositories
{
    public interface IAuctionItemRepository
    {
        Task<IEnumerable<AuctionItem>> GetAllAsync();
        Task<AuctionItem> GetByIdAsync(int id);
        Task<AuctionItem> CreateAsync(AuctionItem createEntity);
        Task<AuctionItem> UpdateAsync(AuctionItem editEntity);
        Task<AuctionItem> DeleteAsync(AuctionItem deleteEntity);
    }
}
