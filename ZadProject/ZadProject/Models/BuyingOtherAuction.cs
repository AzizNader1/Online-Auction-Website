using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    
        public class BuyingOtherAuction
        {
            public int BuyingOtherAuctionId { get; set; }
            public int OtherAuctionId { get; set; }
            public OtherAuction OtherAuction { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }
    }

