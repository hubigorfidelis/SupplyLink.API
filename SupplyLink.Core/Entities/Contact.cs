using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Core.Entities
{
    public class Contact : BaseEntity
    {
        public Contact(string? email, string? phoneNumber, string? secondaryPhoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            SecondaryPhoneNumber = secondaryPhoneNumber;
        }

        public  string? Email { get;private set; }
        public  string? PhoneNumber { get; private set; }
        public string? SecondaryPhoneNumber { get; private set; }
    }
}
