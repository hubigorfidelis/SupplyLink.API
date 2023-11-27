using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.InputModels
{
    public class UpdateSupplierInputModel
    {
        public UpdateSupplierInputModel(int id, string name, SupplierStatusEnum status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public SupplierStatusEnum Status { get; private set; }
    }
}
