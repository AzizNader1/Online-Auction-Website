using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public class RealStateAuctionDto
    {
        [Display(Name = "House Size (in square meters)")]
        [Required(ErrorMessage = "This field can not be empty")]
        public int HouseSize { get; set; }

        [Display(Name = "House Location (Address)")]
        [Required(ErrorMessage = "This field can not be empty")]
        public string HouseAddress { get; set; }

        [Display(Name = "Number Of Rooms")]
        [Required(ErrorMessage = "This field can not be empty")]
        public NumberOfRooms NumberOfRooms { get; set; }

        [Display(Name = "Number Of Bathrooms")]
        [Required(ErrorMessage = "This field can not be empty")]
        public NumberOfBathrooms NumberOfBathrooms { get; set; }

        [Display(Name = "Year Of Build")]
        [Required(ErrorMessage = "This field can not be empty")]
        public YearOfBuild YearOfBuild { get; set; }

        [Display(Name = "Type Of Property")]
        [Required(ErrorMessage = "This field can not be empty")]
        public TypeOfProperty TypeOfProperty { get; set; }

        [Display(Name = "Condition")]
        [Required(ErrorMessage = "This field can not be empty")]
        public RealStateCondition Condition { get; set; }

        [Display(Name = "Have Parking?")]
        [Required(ErrorMessage = "This field can not be empty")]
        public Parking Parking { get; set; }

        [Display(Name = "Starting Price")]
        [Required(ErrorMessage = "This field can not be empty")]
        public int StartingPrice { get; set; }

        [Display(Name = "Minimun Sale Price")]
        [Required(ErrorMessage = "This field can not be empty")]
        public int MinimunSalePrice { get; set; }

        [Display(Name = "Auction Image")]
        [Required(ErrorMessage = "This field can not be empty")]
        public string AuctionImage { get; set; }

        [Display(Name = "Auction Start Date")]
        [Required(ErrorMessage = "this field is required")]
        public DateTime AuctionStartDate { get; set; }

        [Display(Name = "Auction End Date")]
        [Required(ErrorMessage = "this field is required")]
        public DateTime AuctionEndDate { get; set; }

        [Display(Name = "Auction Status")]
        [Required(ErrorMessage = "this field is required")]
        public Status AuctionStatus { get; set; }
        public string AuctionType { get; set; }
        [Display(Name = "Owner Name")]
        [Required(ErrorMessage = "this field is required")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner Phone")]
        [Required(ErrorMessage = "this field is required")]
        public string OwnerPhone { get; set; }
        [Display(Name = "Number of floors")]
        [Required(ErrorMessage = "this field is required")]
        public int NumberOfFloors { get; set; }

        [Display(Name = "VideoLink")]
        [Required(ErrorMessage = "this field is required")]
        public string? VideoLink { get; set; }
    }
}
