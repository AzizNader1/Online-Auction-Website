using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public enum Categories
    {
        [Display(Name ="Furniture")]Furniture,
        [Display(Name = "Arts")] Arts,
        [Display(Name = "Electronics")] Electronics,
        [Display(Name = "Others")] Others
    }
    public enum Status
    {
        Pending,
        Accepted,
        Rejected,
        Complete
    }
    public class OtherAuction
    {
        
        public int OtherAuctionId { get; set; }
        [Display(Name = "Auction Product Name")]
        [Required(ErrorMessage ="this field is required")]
        public string AuctionProdutName { get; set; }
        [Display(Name = "Auction Start Date")]
        [Required(ErrorMessage ="this field is required")]
        public DateTime AuctionStartDate { get; set;}
        [Display(Name = "Auction End Date")] 
        [Required(ErrorMessage ="this field is required")]
        public DateTime AuctionEndDate { get; set;}
        [Display(Name = "Auction Start Price")] 
        [Required(ErrorMessage ="this field is required")]
        public double AuctionStartPrice { get; set;}
        [Display(Name = "MinimumSalePrice")] 
        [Required(ErrorMessage ="this field is required")]
        public double MinimunSalePrice { get;set;}
        [Display(Name = "Auction Cover Image")] 
        [Required(ErrorMessage ="this field is required")]
        public string? AuctionCoverImage { get; set; }
        [Display(Name = "Auction Describtion")] 
        [Required(ErrorMessage ="this field is required")]
        public string AuctionDesctibtion { get; set;}
        [Display(Name = "Auction Category")] 
        [Required(ErrorMessage ="this field is required")]
        public Categories AuctionCategory { get; set;}
        [Display(Name = "Auction Status")] 
        [Required(ErrorMessage ="this field is required")]
        public Status AuctionStatus { get; set;}
        [Display(Name = "Owner Name")]
        [Required(ErrorMessage = "this field is required")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner Phone")]
        [Required(ErrorMessage = "this field is required")]
        public string OwnerPhone { get; set; }

        [Display(Name = "VideoLink")]
        [Required(ErrorMessage = "this field is required")]
        public string VideoLink { get; set; }
        public virtual ICollection<BidingOtherAuction>  BidingOtherAuctions{ get; set;}
    }
}
