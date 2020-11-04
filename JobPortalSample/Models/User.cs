using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace JobPortalSample.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [StringLength(255,ErrorMessage ="Minimum of 8 characters",MinimumLength =8)]
        [RegularExpression("^((?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])|(?=.?[A-Z])(?=.?[a-z])(?=.?[^a-zA-Z0-9])|(?=.?[A-Z])(?=.?[0-9])(?=.?[^a-zA-Z0-9])|(?=.?[a-z])(?=.?[0-9])(?=.?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and should contain : upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string Lastname { get; set; }
        [Display(Name ="Address")]
        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }
        [Display(Name ="Phone Number")]
        [Required(ErrorMessage ="Contact number is required")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Your mobile number is invalid")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Please enter a valid mobile number")]
        public string Mobileno { get; set; }
        [Required]
        [Display(Name ="Highest Qualification")]
        public string Qualification { get; set; }
        [Required]
        [Display(Name ="Year of Passout")]
        public string Year { get; set; }
        [Required]
        [Display(Name = "Experienced/Fresher")]
        public int Experience;
        [Required]
        [Display(Name ="Last Employer")]
        public string Employer { get; set; }
        [Required]
        [Display(Name ="Employer Details")]
        public string EmployerDetails { get; set; }
        
        public virtual ICollection<Application> Applications { get; set; }
    }
}