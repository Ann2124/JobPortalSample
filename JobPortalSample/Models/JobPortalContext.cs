using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JobPortalSample.Models
{
    public class JobPortalContext:DbContext
    {
        public JobPortalContext():base("Name=Dbconfig")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Openings> Openings { get; set; }
    }
}