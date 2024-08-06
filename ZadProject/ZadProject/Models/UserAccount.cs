using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ZadProject.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        [Display(Name = "User Account Number")]
        [Required(ErrorMessage ="this field is required")]
        public string UserAccountNumber { get; set; }
        [Display(Name ="Expire Date")]
        [Required(ErrorMessage ="this field is required")]
        public string ExpireDate { get; set; }
        [Display(Name ="Cvv Number")]
        [Required(ErrorMessage ="this field is required")]
        [DataType(DataType.Password)]
        public int CvvNumber { get; set; }
        [Display(Name = "Account Balance")]
        [Required(ErrorMessage ="this field is required")]
        public double AccountBalance { get; set; }

        [Display(Name = "Holder Name")]
        [Required(ErrorMessage = "this field is required")]
        public string HolderName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set;}
    }
}
