using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.ViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(string name, string document, ClientStatusEnum status)
        {
            Name = name;
            Document = document;
            Status = status;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public ClientStatusEnum Status { get; private set; }
    }
}
