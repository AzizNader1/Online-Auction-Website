using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class UserDto
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "this field is required")]
        public string UserName { get; set; }
        [Display(Name = "User Email")]
        [Required(ErrorMessage = "this field is required")]
        public string UserEmail { get; set; }
        [Display(Name = "User Password")]
        [Required(ErrorMessage = "this field is required")]
        public string UserPassword { get; set; }
        [Display(Name = "User Phone")]
        [Required(ErrorMessage = "this field is required")]
        public string UserPhone { get; set; }
        [Display(Name = "User Address")]
        [Required(ErrorMessage = "this field is required")]
        public string UserAddress { get; set; }
        [Display(Name = "National Id Image")]
        [Required(ErrorMessage = "this field is required")]
        public string? NationalIdImage { get; set; }

    }
}
