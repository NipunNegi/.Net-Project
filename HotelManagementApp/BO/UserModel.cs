using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class UserModel
    {   
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter the Name")]
        [Display(Name ="User Name")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Please enter the Address")]
        [Display(Name = "Address")]
        public String  UserAddress { get; set; }


        [Required(ErrorMessage = "Please enter the Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter valid Email")]
        public String UserEmail { get; set; }

      
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Phone Number")]
        [Required(ErrorMessage = "Please enter the Phone Number")]
        [Display(Name = "Contact Number")]
        public int PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$",
         ErrorMessage = "Min 8 AlphaNumeric Abcdefg2 character")]
        
        public String Password { get; set; }
       
        [Required(ErrorMessage ="Please enter the confirm Password")]
        [Display(Name = " Confirm Password")]
        [Compare("Password",ErrorMessage ="Passwords don't Match")]
        [NotMapped]
        public String ConfirmPassword { get; set; }

       
    }
}
