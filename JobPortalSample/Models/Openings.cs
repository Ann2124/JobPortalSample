﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Deployment;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JobPortalSample.Models
{
    public class Openings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int jobId { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string designation { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public double salary { get; set; }
        [Required]
        [Display(Name = "Experience Required")]
        public string experience { get; set; }
        [Required]
        [Display(Name = "Qualification Required")]
        public string qualification { get; set; }
        [Required]
        [Display(Name = "Job Location")]
        public string location { get; set; }
        [Required]
        [Display(Name = "Vacancies")]
        public int vacancy { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string employerID { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string company { get; set; }

        public virtual Employer employer { get; set; }
        public virtual ICollection<application> applications { get; set; }
    }
}
    