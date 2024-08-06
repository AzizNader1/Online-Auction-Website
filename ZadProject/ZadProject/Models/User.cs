using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="this field is required")]
        public string UserName { get; set; }
        [Display(Name = "User Email")]
        [Required(ErrorMessage ="this field is required")]
        public string UserEmail { get; set; }
        [Display(Name = "User Password")]
        [Required(ErrorMessage ="this field is required")]
        public string UserPassword { get; set; }
        [Display(Name = "National Id Image")]
        [Required(ErrorMessage ="this field is required")]
        public string? NationalIdImage { get; set; }
        [Display(Name = "User Phone")]
        [Required(ErrorMessage ="this field is required")]
        public string UserPhone { get; set; }
        [Display(Name = "User Address")]
        [Required(ErrorMessage ="this field is required")]
        public string UserAddress { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
        public virtual ICollection<BuyingOtherAuction> BuyingOtherAuctions { get; set; }
        public virtual ICollection<BuyingRealStateAuction> BuyingRealStateAuctions { get; set; }
        public virtual ICollection<BuyingCarAuction> BuyingCarAuctions { get; set; }
        public virtual ICollection<BidingOtherAuction> BidingOtherAuctions { get; set; }
        public virtual ICollection<BidingRealStateAuction> BidingRealStateAuctions { get; set; }
        public virtual ICollection<BidingCarAuction> BidingCarAuctions { get; set; }
    }
}
