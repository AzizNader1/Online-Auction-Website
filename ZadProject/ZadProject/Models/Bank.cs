using System.ComponentModel.DataAnnotations;

namespace ZadProject.Models
{
    public class Bank
    {
        public int BankId { get; set; }
        [Display(Name ="Bank Name")]
        [Required(ErrorMessage ="this field is required")]
        public string BankName { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
