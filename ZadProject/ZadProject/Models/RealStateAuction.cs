using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public enum YearOfBuild
    {
        [Display(Name = "2024")] Year2024,
        [Display(Name = "2023")] Year2023,
        [Display(Name = "2022")] Year2022,
        [Display(Name = "2021")] Year2021,
        [Display(Name = "2020")] Year2020,
        [Display(Name = "2019")] Year2019,
        [Display(Name = "2018")] Year2018,
        [Display(Name = "2017")] Year2017,
        [Display(Name = "2016")] Year2016,
        [Display(Name = "2015")] Year2015,
        [Display(Name = "2014")] Year2014,
        [Display(Name = "2013")] Year2013,
        [Display(Name = "2012")] Year2012,
        [Display(Name = "2011")] Year2011,
        [Display(Name = "2010")] Year2010,
        [Display(Name = "2009")] Year2009,
        [Display(Name = "2008")] Year2008
    }
    public enum TypeOfProperty
    {
        [Display(Name = "Villa")] Villa,
        [Display(Name = "Apartment")] Apartment,
        [Display(Name = "Detached House")] DetachedHouse
    }
    public enum RealStateCondition
    {
        [Display(Name = "New")] New,
        [Display(Name = "Used")] Used
    }
    public enum NumberOfRooms
    {
        [Display(Name = "6")] Six,
        [Display(Name = "5")] Five,
        [Display(Name = "4")] Four,
        [Display(Name = "3")] Three,
        [Display(Name = "2")] Two,
        [Display(Name = "1")] One,
    }
    public enum NumberOfBathrooms
    {
        [Display(Name = "6")] Six,
        [Display(Name = "5")] Five,
        [Display(Name = "4")] Four,
        [Display(Name = "3")] Three,
        [Display(Name = "2")] Two,
        [Display(Name = "1")] One,
    }
   
    public enum Parking
    {
        [Display(Name = "Yes")] Yes,
        [Display(Name = "No")] No
    }
    public class RealStateAuction
    {
        public int RealStateAuctionId { get; set; }

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

        [Display(Name ="Have Parking?")]
        [Required(ErrorMessage ="This field can not be empty")]
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

        [Display(Name ="Number of floors")]
        [Required(ErrorMessage ="this field is required")]
        public int NumberOfFloors { get; set; }

        [Display(Name = "VideoLink")]
        [Required(ErrorMessage = "this field is required")]
        public string VideoLink { get; set; }
        public virtual ICollection<BidingRealStateAuction> BidingRealStateAuctions { get; set; }
    }
}
