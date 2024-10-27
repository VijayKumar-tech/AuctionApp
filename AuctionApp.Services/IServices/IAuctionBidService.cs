using AuctionApp.DataLayer.Dtos;

namespace AuctionApp.Services.IServices
{
    public interface IAuctionBidService
    {
        Task<AuctionBidDto> CreateServiceAsync(AuctionBidDto createEntity);

    }
}
