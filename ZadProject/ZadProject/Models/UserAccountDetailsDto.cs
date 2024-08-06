using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class UserAccountDetailsDto
    {
        public int Id { get; set; }
        [Display(Name = "User Account Number")]
        [Required(ErrorMessage = "this field is required")]
        public string UserAccountNumber { get; set; }
        [Display(Name = "Expire Date")]
        [Required(ErrorMessage = "this field is required")]
        public string ExpireDate { get; set; }
        [Display(Name = "Cvv Number")]
        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.Password)]
        public int CvvNumber { get; set; }
        [Display(Name = "Account Balance")]
        [Required(ErrorMessage = "this field is required")]
        public double AccountBalance { get; set; }

        [Display(Name = "Holder Name")]
        [Required(ErrorMessage = "this field is required")]
        public string HolderName { get; set; }

        public string BankName { get; set; }
    }
}
