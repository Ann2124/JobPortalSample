using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalSample.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Job ID")]
        public int JobId { get; set; }
        public string Status { get; set; }


        public virtual User user { get; set; }
        public virtual Openings Openings { get; set; }
    }
    public enum Experience
    {
        No_Experience,
        Upto_6_Months,
        One_Year,
        One_Year_to_Two_Years,
        More_than_Two_Years
    }
}