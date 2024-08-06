using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class BidingCarAuction
    {
        public int BidingCarAuctionId { get; set; }

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

        public int CarAuctionId { get; set; }
        public CarAuction CarAuction { get; set; }
    }
}
