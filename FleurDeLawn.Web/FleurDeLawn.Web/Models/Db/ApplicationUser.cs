using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FleurDeLawn.Web.Models.Db
{
    public class ApplicationUser: IdentityUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public ApplicationUser()
        {
            Addresses = new List<Address>();
        }

    }

    public 
}

