using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Application.ViewModels;
using SupplyLink.Core.Entities;
using SupplyLink.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Services.Implementations
{
    public class SupplierService : ISupplierService
    {

        private readonly SupplyLinkDbContext _dbcontext;

        public SupplierService(SupplyLinkDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public int Create(NewSupplierInputModel inputModel)
        {

            var supplier = new Supplier(inputModel.Name, inputModel.Document, inputModel.Login, inputModel.Status, inputModel.CreateAt);
            _dbcontext.Suppliers.Add(supplier);

            _dbcontext.SaveChanges();
            return supplier.Id;
        }
       public void Delete(int id)
        {
            var supplier = _dbcontext.Suppliers.SingleOrDefault(supplier => supplier.Id == id);
            if (supplier == null)
            {
                throw new Exception("Not Found");
            }
            supplier.Block(supplier.Status);
            _dbcontext.SaveChanges();
        }

        public List<SupplierViewModel> GetAll(string query)
        {
            var suppliers = _dbcontext.Suppliers;

            var supplierViewModel = suppliers
                .Select(p => new SupplierViewModel(p.Name, p.Document, p.Status))
                .ToList();

            return supplierViewModel;
        }

        public SupplierDetailsViewModel GetById(int id)
        {
            var supplier = _dbcontext.Suppliers.SingleOrDefault(supplier => supplier.Id == id);

            var supplierDetaisViewModel = new SupplierDetailsViewModel(
                supplier.Id,
                supplier.Name,
                supplier.Document,
                supplier.Login,
                (Core.Enums.ClientStatusEnum)supplier.Status,
                supplier.CreateAt

                );
         
            return supplierDetaisViewModel;
        }

        public void Update(UpdateSupplierInputModel inputModel)
        {
            var supplier = _dbcontext.Suppliers.SingleOrDefault(supplier => supplier.Id == inputModel.Id); 
            
            supplier.Update(inputModel.Name,inputModel.Status);

            _dbcontext.SaveChanges();
        }

    }
}
