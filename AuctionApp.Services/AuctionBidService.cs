using AuctionApp.DataLayer.Dtos;
using AuctionApp.DataLayer.Models;
using AuctionApp.Repositories;
using AuctionApp.Repositories.IRepositories;
using AuctionApp.Services.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Services
{
    public class AuctionBidService : IAuctionBidService
    {
        private readonly IAuctionBidRepository _auctionBidRepository;
        private readonly IMapper _mapper;

        public AuctionBidService(IAuctionBidRepository auctionBidRepository, IMapper mapper)
        {
            _auctionBidRepository = auctionBidRepository;
            _mapper = mapper;
        }
        public async Task<AuctionBidDto> CreateServiceAsync(AuctionBidDto createEntity)
        {
            try
            {
                var mapResult = _mapper.Map<AuctionBid>(createEntity);
                var result = await _auctionBidRepository.CreateAsync(mapResult);
                var resultDto = _mapper.Map<AuctionBidDto>(result);

                if (result == null)
                {
                    throw new Exception("Creation Failed.");
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
    }
}
