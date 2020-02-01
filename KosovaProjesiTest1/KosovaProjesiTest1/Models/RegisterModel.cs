using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KosovaProjesiTest1.Models
{
    public class RegisterModel
    {
       
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Doğru bir e-mail giriniz.")]
        public string Email { get; set; }
    }
}
