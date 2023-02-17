using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickKartMVC.Models
{
    public class Users
    {
        [Key]
        // Email Id
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]   //Check if format of email is valid
        [Required(ErrorMessage ="Email is mandatory")]
        [DisplayName("Email")]
        public string EmailId { get; set; }

        // User Password
        [MinLength(5)]
        [Required(ErrorMessage = "User Password is mandatory")]
        [DisplayName("Password")]
        public string userPassword { get; set; }

        // Role Id
        public Nullable<byte> RoleId { get; set; }

        // Gender
        [RegularExpression("M|F", ErrorMessage = "Gender Should be M or F")]
        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }

        // Date of birth
        [Required(ErrorMessage = "Date of Birth is mandatory")]
        [DisplayName("Date of Birth")]
        public DateTime DateofBirth { get; set; }

        // Address
        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; }
    }
}
