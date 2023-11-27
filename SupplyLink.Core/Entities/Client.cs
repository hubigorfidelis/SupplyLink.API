using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Core.Entities
{
    public class Client : BaseEntity
    {
        public Client(string name, string document, string login, ClientStatusEnum status, DateTime createAt)
        {
            Name = name;
            Document = document;
            Login = login;
            Status = status;
            CreateAt = createAt;
            Address = new List<Address>();
            Contact = new List<Contact>();
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Login { get; private set; }
        public ClientStatusEnum Status { get; private set; }
        public DateTime CreateAt { get; private set; }

        public List<Address> Address { get; private set; }

        public List< Contact> Contact { get; private set; }

        
        public void Inactive () 
        {   
            if (Status == ClientStatusEnum.Active)
            {
                Status = ClientStatusEnum.Inative;
            }
        }

        public void Update(string name , ClientStatusEnum status)
        {
            Name += name;
            Status = status;
        }
        
    }
}
