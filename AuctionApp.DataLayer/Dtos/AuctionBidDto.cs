using AuctionApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer.Dtos
{
    public class AuctionBidDto : EntityDto
    {
        public decimal Amount { get; set; }
        public int AuctionItemId { get; set; }
        public virtual AuctionItemDto? AuctionItem { get; set; }
        public int UserId { get; set; }
        public virtual UserDto? User { get; set; }
    }
}
