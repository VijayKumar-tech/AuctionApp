using AuctionApp.DataLayer.Dtos;
using AuctionApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Services.IServices
{
    public interface IAuctionItemService
    {
        Task<IEnumerable<AuctionItemDto>> GetAllServiceAsync();
        Task<AuctionItemDto> GetByIdServiceAsync(int id);
        Task<AuctionItemDto> CreateServiceAsync(AuctionItemDto createEntity);
        Task<AuctionItemDto> UpdateServiceAsync(AuctionItemDto editEntity);
        Task<AuctionItemDto> DeleteServiceAsync(int id);
    }
}
