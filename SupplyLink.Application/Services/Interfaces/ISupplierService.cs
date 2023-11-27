using SupplyLink.Application.InputModels;
using SupplyLink.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierViewModel> GetAll(string query);

        SupplierDetailsViewModel GetById(int id);

        int Create(NewSupplierInputModel inputModel);

        void Update(UpdateSupplierInputModel inputModel);

        void Delete(int id);

    }
}

