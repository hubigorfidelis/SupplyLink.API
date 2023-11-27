using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier(string name, string document, string login, SupplierStatusEnum status, DateTime createAt)
        {
            Name = name;
            Document = document;
            Login = login;
            Status = status;
            CreateAt = createAt;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Login { get; private set; }
        public SupplierStatusEnum Status { get; private set; }
        public DateTime CreateAt { get; private set; }

        public List<Address> Address { get; private set; }

        public List<Contact> Contact { get; private set; }

        public void Block(SupplierStatusEnum status)
        {
            status= SupplierStatusEnum.Blocked;
        }

        public void Update(string name, SupplierStatusEnum status)
        {
            Name = name;
            Status = status;
            
        }

    }
}

