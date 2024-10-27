using AuctionApp.DataLayer.Dtos;
using AuctionApp.DataLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
                CreateMap<User, UserDto>();
                CreateMap<UserDto, User>();

                CreateMap<AuctionItem, AuctionItemDto>();
                CreateMap<AuctionItemDto, AuctionItem>();

                CreateMap<AuctionBid, AuctionBidDto>();
                CreateMap<AuctionBidDto, AuctionBid>();
        }
    }
}
