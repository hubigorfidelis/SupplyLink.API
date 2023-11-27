using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address(string street, string city, string state, string zipCode, string country, int idClient)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            IdClient = idClient;

        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public int IdClient { get; set; }

      
    }
}
