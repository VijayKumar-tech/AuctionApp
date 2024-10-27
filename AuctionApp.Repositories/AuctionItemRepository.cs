using AuctionApp.DataLayer;
using AuctionApp.DataLayer.Models;
using AuctionApp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace AuctionApp.Repositories
{
    public class AuctionItemRepository : IAuctionItemRepository
    {
        private readonly AuctionContext _auctionContext;
        public AuctionItemRepository(AuctionContext auctionContext)
        {
            _auctionContext = auctionContext;
        }
        public async Task<AuctionItem> CreateAsync(AuctionItem createEntity)
        {
            createEntity.CreatedDate = DateTime.UtcNow;
            _auctionContext.AuctionItems.Add(createEntity);
            await _auctionContext.SaveChangesAsync();
            return createEntity;
        }

        public async Task<AuctionItem> DeleteAsync(AuctionItem deleteEntity)
        {
            deleteEntity.ModifiedDate = DateTime.UtcNow;
            deleteEntity.IsDeleted = true;
            _auctionContext.Entry(deleteEntity).Property("ModifiedDate").IsModified = true;
            _auctionContext.Entry(deleteEntity).Property("IsDeleted").IsModified = true;
            await _auctionContext.SaveChangesAsync();
            return deleteEntity;
        }

        public async Task<IEnumerable<AuctionItem>> GetAllAsync()
        {
            return await _auctionContext.AuctionItems.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<AuctionItem> GetByIdAsync(int id)
        {
            return await _auctionContext.AuctionItems.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<AuctionItem> UpdateAsync(AuctionItem editEntity)
        {
            editEntity.ModifiedDate = DateTime.UtcNow;
            _auctionContext.Update(editEntity);
            await _auctionContext.SaveChangesAsync();
            return editEntity;
        }

    }
}
