using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer.Dtos
{
    public class AuctionItemDto : EntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingBid { get; set; }
        public DateTime EndDate { get; set; }
    }
}
