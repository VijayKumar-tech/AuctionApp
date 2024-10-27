using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer.Models
{
    public class AuctionBid : Entity
    {
        public decimal Amount { get; set; }
        public int AuctionItemId { get; set; }
        public virtual AuctionItem? AuctionItem { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
