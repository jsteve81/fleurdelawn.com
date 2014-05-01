using FleurDeLawn.Web.Models;
using FleurDeLawn.Web.Models.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FleurDeLawn.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FleurDeLawn.Web.Models.FleurDeLawnDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FleurDeLawn.Web.Models.FleurDeLawnDbContext context)
        {
            var address = new Address()
            {
                Address1 = "5335 Citrus Blvd",
                Address2 = "Apt. K360",
                City = "New Orleans",
                State = "LA",
                Zip = "70123"
            };

            context.Addresses.Add(address);

            var store = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(store);

            var jonathan = new ApplicationUser
            {
                FirstName = "Jonathan",
                LastName = "Stevenson",
                UserName = "jsteve81"
            };

            var kellie = new ApplicationUser
            {
                FirstName = "Kellie",
                LastName = "Walker",
                UserName = "kwalker"
            };

            var jonathanResult = userManager.Create(jonathan, "121472");
            var kellieResult = userManager.Create(kellie, "121472");

            if (kellieResult.Succeeded && jonathanResult.Succeeded)
            {
                address.ApplicationUsers.Add(jonathan);
                address.ApplicationUsers.Add(kellie);
                context.SaveChanges();
            }  
        }
    }
}
