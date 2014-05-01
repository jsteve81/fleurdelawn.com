using System.Collections.Generic;

namespace FleurDeLawn.Web.Models.Db
{
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public Address()
        {
            ApplicationUsers = new List<ApplicationUser>();
        }
    }
}