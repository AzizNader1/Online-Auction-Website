using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZadProject.Models
{
    public class RealStateDetailsView
    {
        public RealStateAuction RealStateAuction { get; set; }
        public List<BidingRealStateAuction> BidingStateAuction { get; set; }
        public int BidNumber { get; set; }
    }
}
