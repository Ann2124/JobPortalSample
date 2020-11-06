using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalSample.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalSample.Models
{
    public class Openings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        [Required]
        [Display(Name ="Designation")]
        public string Designation { get; set; }
        [Required]
        [Display(Name ="Salary")]
        public double Salary { get; set; }
        [Required]
        [Display(Name ="Experience Required")]
        public string Experience { get; set; }
        [Required]
        [Display(Name ="Qualification Required")]
        public string Qualification { get; set; }
        [Required]
        [Display(Name ="Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name ="Vacancies")]
        public int Vacancy { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string EmployerID { get; set; }
        [Required]
        [Display(Name ="Company")]
        public string Company { get; set; }

        public virtual Employer employer { get; set; }
        public virtual ICollection<Application> applications { get; set; }
    }
}