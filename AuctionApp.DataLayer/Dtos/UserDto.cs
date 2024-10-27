using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.DataLayer.Dtos
{
    public class UserDto : EntityDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }

    public class LoginDto
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
