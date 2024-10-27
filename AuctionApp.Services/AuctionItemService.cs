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
    public class AuctionItemService : IAuctionItemService
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        private readonly IMapper _mapper;

        public AuctionItemService(IAuctionItemRepository auctionItemRepository, IMapper mapper)
        {
            _auctionItemRepository = auctionItemRepository;
            _mapper = mapper;
        }
        public async Task<AuctionItemDto> CreateServiceAsync(AuctionItemDto createEntity)
        {
            try
            {
                var mapResult = _mapper.Map<AuctionItem>(createEntity);
                var result = await _auctionItemRepository.CreateAsync(mapResult);
                var resultDto = _mapper.Map<AuctionItemDto>(result);

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

        public async Task<AuctionItemDto> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _auctionItemRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException("Record Not Found");
                }
                else
                {
                    var result = await _auctionItemRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception("Deletion  Failed");
                    }
                    else
                    {
                        var resultDto = _mapper.Map<AuctionItemDto>(result);
                        return resultDto;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<AuctionItemDto>> GetAllServiceAsync()
        {
            try
            {
                var result = await _auctionItemRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<AuctionItemDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return destObjects;
                }
                else
                {
                    throw new KeyNotFoundException("No Records Found");
                }
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AuctionItemDto> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _auctionItemRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<AuctionItemDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException("Record Not Found");
                }
                else
                {
                    return destObject;
                }
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AuctionItemDto> UpdateServiceAsync(AuctionItemDto editEntity)
        {
            try
            {
                var found = await _auctionItemRepository.GetByIdAsync(editEntity.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException("No Record Found");
                }
                else
                {
                    var obj = _mapper.Map(editEntity, found);

                    var result = await _auctionItemRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception("Update Failed");
                    }
                    else
                    {
                        var resultDto = _mapper.Map<AuctionItemDto>(result);
                        return resultDto;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
