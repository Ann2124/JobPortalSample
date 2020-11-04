using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalSample.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int applicationId { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Job Id")]
        public int jobId { get; set; }
        public string status { get; set; }


        public virtual User user { get; set; }
        public virtual Openings Openings { get; set; }
    }
}