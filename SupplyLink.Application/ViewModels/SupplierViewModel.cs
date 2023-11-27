using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.ViewModels
{
    public class SupplierViewModel
    {
        public SupplierViewModel(string name, string document, SupplierStatusEnum status)
        {
            Name = name;
            Document = document;
            Status = status;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public SupplierStatusEnum Status { get; private set; }
    }
}
