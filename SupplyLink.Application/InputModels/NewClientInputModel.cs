using SupplyLink.Core.Entities;
using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.InputModels
{
    public class NewClientInputModel
    {
        public string Name { get;  set; }
        public string Document { get;  set; }
        public string Login { get; set; }
        public ClientStatusEnum Status { get;  set; }
        public DateTime CreateAt { get;  set; }

        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
    }
}
