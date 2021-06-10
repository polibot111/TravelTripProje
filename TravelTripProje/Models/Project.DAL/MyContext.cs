using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Project.Entities;

namespace TravelTripProje.Models.Project.DAL
{
    public class MyContext:DbContext
    {
        public MyContext(): base("myConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>().HasRequired(current => current.Blog)
           .WithMany(c => c.Comments)
           .HasForeignKey(c => c.BlogID)
           .WillCascadeOnDelete(true);
        }
        public DbSet<AboutUss> AboutUss { get; set; }
        public DbSet<Adminss> Adminss { get; set; }
        public DbSet<Address> Adressess { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Homes> Homes { get; set; }
        public DbSet<ContactUss> ContactUss { get; set; }

    }
}