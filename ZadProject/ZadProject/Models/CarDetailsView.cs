using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZadProject.Models
{
    public class CarDetailsView
    {
        public CarAuction CarAuction { get; set; }
        public List<BidingCarAuction> BidingCarAuction { get; set; }
        public int BidNumber { get; set; }
    }
}
