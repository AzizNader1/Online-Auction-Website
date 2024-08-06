using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public class BidingOtherAuction
    {
        public int BidingOtherAuctionId { get; set; }

        [Display(Name ="Biding Price")]
        [Required(ErrorMessage ="this field can't be empty")]
        public double BidingPrice { get; set; }

        [Display(Name = "Biding Date")]
        [Required(ErrorMessage = "this field can't be empty")] 
        public DateTime BidingDate { get; set; }

        [Display(Name = "Biding Type")]
        [Required(ErrorMessage = "this field can't be empty")]
        public int UserId { get; set; }
        public User User { get; set; }

        public int OtherAuctionId { get; set; }
        public OtherAuction OtherAuction { get; set; }


    }
}
