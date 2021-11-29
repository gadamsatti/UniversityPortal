using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityPortal.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please Enter Name e.g. Aaron")]
        [Display(Name ="First Name")]
        [StringLength(30, MinimumLength = 4)]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Please Enter Name e.g. Hawkins")]
        [Display(Name ="Last Name")]
        [StringLength(30, MinimumLength = 4)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter DateOfBirth")]
        [Display(Name="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Please Enetr Gender")]
        [Display(Name ="Gender")]
        public string Gender { get; set; }



        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        public long ContactNo { get; set; }



        [Required(ErrorMessage = "Please enter your User ID e.g. 11XX minnimum=4")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }



        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }



        [Required(ErrorMessage ="Please Enter Strong Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage ="Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
