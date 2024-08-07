using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public class CarAuctionDto
    {
        [Display(Name = "Car Model")]
        [Required(ErrorMessage = "This field can't be empty")]
        public CarModels CarModel { get; set; }

        [Display(Name = "Year Of Manufacture")]
        [Required(ErrorMessage = "This field can't be empty")]
        public YearOfManufacture YearOfManufacture { get; set; }

        [Display(Name = "Fuel Type")]
        [Required(ErrorMessage = "This field can't be empty")]
        public FuelType FuelType { get; set; }
        [Display(Name = "Number of kilometers")]
        [Required(ErrorMessage = "this field can not be empty")]
        public int NOK { get; set; }
        [Display(Name = "Number of Previous Owner")]
        [Required(ErrorMessage = "this field can not be empty")]
        public NumberOfOwner NumberOfOwner { get; set; }

        [Display(Name = "Warranty")]
        [Required(ErrorMessage = "this field can not be empty")]
        public HasWarranty Warranty { get; set; }

        [Display(Name = "Technical Inspection")]
        [Required(ErrorMessage = "this field can not be empty")]
        public TechnicalInspection TechnicalInspection { get; set; }

        [Display(Name = "Video Link")]
        [Required(ErrorMessage = "this field can not be empty")]
        public string? VideoLink { get; set; }

        [Display(Name = "Condition")]
        [Required(ErrorMessage = "This field can't be empty")]
        public Condition Condition { get; set; }

        [Display(Name = "Transmisssion Type")]
        [Required(ErrorMessage = "This field can't be empty")]
        public TransmisssionType TransmisssionType { get; set; }

        [Display(Name = "Colors")]
        [Required(ErrorMessage = "This field can't be empty")]
        public Colors Colors { get; set; }

        [Display(Name = "Number Of Doors")]
        [Required(ErrorMessage = "This field can't be empty")]
        public NumberOfDoors NumberOfDoors { get; set; }

        [Display(Name = "Accident Before")]
        [Required(ErrorMessage = "This field can't be empty")]
        public AccidentBefore AccidentBefore { get; set; }

        [Display(Name = "Tire Condition")]
        [Required(ErrorMessage = "This field can't be empty")]
        public TireCondition TireCondition { get; set; }

        [Display(Name = "Starting Price")]
        [Required(ErrorMessage = "This field can't be empty")]
        public int StartingPrice { get; set; }

        [Display(Name = "Minimun Sale Price")]
        [Required(ErrorMessage = "This field can't be empty")]
        public int MinimunSalePrice { get; set; }

        [Display(Name = "Auction Image")]
        [Required(ErrorMessage = "This field can't be empty")]
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
    }
}
