using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        [StringLength(255, ErrorMessage = "Password should contain minimum of 8 characters", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and should contain : upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm your password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name ="Firstname")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name ="Lastname")]
        public string Lastname { get; set; }
        [Display(Name ="Address")]
        [Required(ErrorMessage ="Enter the address")]
        public string Address { get; set; }
        [Display(Name ="Contact Number")]
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Your mobile number  is not valid")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Please enter a valid mobile number")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name ="Highest Qualification")]
        public string Qualification { get; set; }
        [Required]
        [Display(Name ="Year of completion")]
        public string Year { get; set; }
        [Required]
        [Display(Name = "Experienced/Fresher")]
        public string Experience { get; set; }
        [Required]
        [Display(Name = "Experience")]
        public int YearOfExperience { get; set; }
        [Required]
        [Display(Name ="Last Employer")]
        public string Employer { get; set; }
        [Required]
        [Display(Name ="Employer Details")]
        public string EmployerDetails { get; set; }

        public virtual ICollection<Application> applications { get; set; }
    }
    public enum Experiences
    {
        Experienced,
        Fresher
    }
    public enum Qualifications
    {
        No_Former_Education,
        Primary_Education,
        Secondary_Education,
        plus_two,
        Diploma,
        Bachelor_of_Arts,
        Bachelor_of_Commerce,
        Bachelor_of_Technology,
        Bsc,
        Bca,
        Bba,
        Ma,
        Mcom,
        Mtech,
        MBA,
        Msc,
        Mca,
        Phd,
        Mphil
    }

}