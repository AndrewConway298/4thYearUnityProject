using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScoresWebsite.Models
{
    public class Player
    {
        [Display(Name = "User ID")]
        public long Id { get; set; }
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your Password must match the Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Paying User")]
        public bool PaymentVerified { get; set; }

        public int Score { get; set; }

        //public bool RememberMe { get; set; }
    }
}