using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZadProject.Models
{
    public class OtherDetailsView
    {
        public OtherAuction OtherAuction { get; set; }
        public List<BidingOtherAuction> BidingOtherAuction { get; set; }
        public int BidNumber { get; set; }
    }
}
