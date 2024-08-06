using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadProject.Models
{
    public enum CarModels
    {
        [Display(Name ="Toyota")] Toyota,
        [Display(Name = "Honda")] Honda,
        [Display(Name = "Ford")] Ford,
        [Display(Name = "Nissan")] Nissan,
        [Display(Name = "Chevrolet")] Chevrolet,
        [Display(Name = "Mercedes")] Mercedes,
        [Display(Name = "BMW")] BMW,
        [Display(Name = "Hyundai")] Hyundai,
        [Display(Name = "Kia")] Kia,
        [Display(Name = "Volkswagen")] Volkswagen,
        [Display(Name = "Audi")] Audi,
    }
    public enum YearOfManufacture 
    {
        [Display(Name ="2024")] Year2024,
        [Display(Name ="2023")] Year2023,
        [Display(Name ="2022")] Year2022,
        [Display(Name ="2021")] Year2021,
        [Display(Name ="2020")] Year2020,
        [Display(Name ="2019")] Year2019,
        [Display(Name ="2018")] Year2018,
        [Display(Name ="2017")] Year2017,
        [Display(Name ="2016")] Year2016,
        [Display(Name ="2015")] Year2015,
        [Display(Name ="2014")] Year2014,
        [Display(Name ="2013")] Year2013,
        [Display(Name ="2012")] Year2012,
        [Display(Name ="2011")] Year2011,
        [Display(Name ="2010")] Year2010,
        [Display(Name ="2009")] Year2009,
        [Display(Name ="2008")] Year2008
    }
    public enum FuelType
    {
        [Display(Name = "Gasoline")] Gasoline,
        [Display(Name = "Diesel")] Diesel,
        [Display(Name = "Electric")] Electric
    }
    public enum Condition
    {
        [Display(Name ="New")] New,
        [Display(Name = "Used")] Used
    }
    public enum TransmisssionType
    {
        [Display(Name = "Manual")] Manual,
        [Display(Name = "Automatic")] Automatic
    }
    public enum Colors
    {
        [Display(Name = "White")] White,
        [Display(Name = "Black")] Black,
        [Display(Name = "Gray")] Gray,
        [Display(Name = "Silver")] Silver,
        [Display(Name = "Blue")] Blue,
        [Display(Name = "Red")] Red,
        [Display(Name = "Green")] Green,
        [Display(Name = "Brown")] Brown,
        [Display(Name = "Gold")] Gold,
        [Display(Name = "Orange")] Orange,
        [Display(Name = "Purple")] Purple,
        [Display(Name = "New")] New
    }
    public enum NumberOfDoors 
    {
        [Display(Name ="6")] Six,
        [Display(Name ="5")] Five,
        [Display(Name ="4")] Four,
        [Display(Name ="3")] Three,
        [Display(Name ="2")] Two,
        [Display(Name ="1")] Onw,
    }
    public enum AccidentBefore 
    {
        [Display(Name ="Yes")] Yes,
        [Display(Name ="No")] No,
    }
    public enum TireCondition 
    {
        [Display(Name = "New")] New,
        [Display(Name = "Used")] Used,
    }

    public enum HasWarranty
    {
        [Display(Name = "Yes")] Yes,
        [Display(Name = "No")] No,
    }

    public enum NumberOfOwner
    {
        [Display(Name = "6")] Six,
        [Display(Name = "5")] Five,
        [Display(Name = "4")] Four,
        [Display(Name = "3")] Three,
        [Display(Name = "2")] Two,
        [Display(Name = "1")] One,
    }

    public enum TechnicalInspection
    {
        [Display(Name = "Yes")] Yes,
        [Display(Name = "No")] No,
    }
    public class CarAuction
    {
        public int CarAuctionId { get; set; }

        [Display(Name ="Car Model")]
        [Required(ErrorMessage ="This field can't be empty")]
        public CarModels CarModel { get; set; }

        [Display(Name = "Year Of Manufacture")]
        [Required(ErrorMessage = "This field can't be empty")] 
        public YearOfManufacture YearOfManufacture { get; set; }

        [Display(Name = "Fuel Type")]
        [Required(ErrorMessage = "This field can't be empty")] 
        public FuelType FuelType { get; set; }
        [Display(Name ="Number of kilometers")]
        [Required(ErrorMessage ="this field can not be empty")]
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
        public string VideoLink { get; set; }

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

        public virtual ICollection<BidingCarAuction> BidingCarAuctions { get; set; }
    }
}
