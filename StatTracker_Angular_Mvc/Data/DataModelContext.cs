using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class DataModelContext : DbContext
    {
        public DataModelContext()
            : base("name=GolfStatTrackerEntities")
        {
            Database.SetInitializer<Data.DataModelContext>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
    
        public DbSet<Course> Courses { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        //public DbSet<Golfer> Golfers { get; set; }
        //public DbSet<Hole> Holes { get; set; }
        //public DbSet<Round> Rounds { get; set; }
        //public DbSet<RoundDetail> RoundDetails { get; set; }
        //public DbSet<Tee> Tees { get; set; }
    }
}