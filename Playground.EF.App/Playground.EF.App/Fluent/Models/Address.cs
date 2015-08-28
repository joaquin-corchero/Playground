using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Playground.EF.App.Fluent.Models
{
    public class Address
    {
        public int ArtistId { get; private set; }

        public string Address1 { get; protected set; }

        public string Address2 { get; protected set; }

        public string PostCode { get; protected set; }

        public string City { get; protected set; }

        public string County { get; protected set; }

        public string Country { get; protected set; }

        public virtual Artist Artist { get; protected set; }

        protected Address() { }

        private Address(string address1, string address2, string postCode, string city, string county, string country)
        {
            Address1 = address1;
            Address2 = address2;
            PostCode = postCode;
            City = city;
            County = county;
            Country = country;
        }

        public static Address Generate(string address1, string address2, string postCode = "PO0 BO1", string city = "London", string county = "Greater London", string country = "GB")
        {
            return new Address(address1, address2, postCode, city, county, country);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Address1, Address2, PostCode, City, County, Country);
        }
    }
}