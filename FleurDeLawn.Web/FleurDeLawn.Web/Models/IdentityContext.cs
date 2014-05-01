using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using FleurDeLawn.Web.Models.Db;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FleurDeLawn.Web.Models
{
    public class FleurDeLawnDbContext : IdentityDbContext<ApplicationUser>
    {
        public FleurDeLawnDbContext()
            : base("DefaultConnection")
        {}

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(x=>x.Id)
                .ToTable("Address")
                .HasMany(x => x.ApplicationUsers)
                .WithMany(x => x.Addresses)
                .Map(mc =>
                {
                    mc.ToTable("UserAddress");
                    mc.MapLeftKey("AddressId");
                    mc.MapRightKey("UserId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}