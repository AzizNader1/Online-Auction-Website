using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class BidingRealStateAuction
    {
        public int BidingRealStateAuctionId { get; set; }

        [Display(Name = "Biding Price")]
        [Required(ErrorMessage = "this field can't be empty")]
        public double BidingPrice { get; set; }

        [Display(Name = "Biding Date")]
        [Required(ErrorMessage = "this field can't be empty")]
        public DateTime BidingDate { get; set; }

        [Display(Name = "Biding Type")]
        [Required(ErrorMessage = "this field can't be empty")]
        public int UserId { get; set; }
        public User User { get; set; }

        public int RealStateAuctionId { get; set; }
        public RealStateAuction RealStateAuction { get; set; }
    }
}
