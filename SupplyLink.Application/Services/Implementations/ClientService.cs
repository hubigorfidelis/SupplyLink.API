using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Application.ViewModels;
using SupplyLink.Core.Entities;
using SupplyLink.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Services.Implementations
{
    public class ClientService : IClientService
    {

        private readonly SupplyLinkDbContext _dbcontext;

        public ClientService(SupplyLinkDbContext dbContext) 
        {
            _dbcontext = dbContext;
        }
        public int Create(NewClientInputModel inputModel)
        {
            var valide = false;
            
            if(inputModel.Document.Length == 14) 
            {
              var isvalid = Validators.ValidaCnpj.IsCnpj(inputModel.Document);
               if(isvalid)
                {
                    valide = true;
                }    
            }
            if (inputModel.Document.Length == 11)
            {
                var isvalid = Validators.ValidaCPF.IsCpf(inputModel.Document);
                if (isvalid)
                {
                    valide = true;
                }

            }
            var client = new Client(inputModel.Name, inputModel.Document, inputModel.Login, inputModel.Status, inputModel.CreateAt);
            if (valide)
            {
                _dbcontext.Clients.Add(client);

            }
            else
            {
                throw new Exception();
            }
            _dbcontext.SaveChanges();
            return client.Id;
        }

        public void Delete(int id)
        {
            var client = _dbcontext.Clients.SingleOrDefault(client => client.Id == id);
            if(client == null)
            {
                throw new Exception("Not Found");
            }

            _dbcontext.Remove(client);
            _dbcontext.SaveChanges();
        }

        public List<ClientViewModel> GetAll(string query)
        {
            var clients = _dbcontext.Clients;

            var clientViewModel = clients
                .Select(p => new ClientViewModel(p.Name, p.Document, p.Status))
                .ToList();

            return clientViewModel;
        }

        public ClientDetailsViewModel GetById(int id)
        {
            var client = _dbcontext.Clients.SingleOrDefault(client => client.Id == id);

            var clientDetaisViewModel = new ClientDetailsViewModel(
                client.Id,
                client.Name,
                client.Document,
                client.Login,
                client.Status,
                client.CreateAt                

                );
            return clientDetaisViewModel;
        }

        public void Update(UpdateClientInputModel inputModel)
        {
            var client = _dbcontext.Clients.SingleOrDefault(client => client.Id == inputModel.Id); ;

            client.Update(inputModel.Name, inputModel.Status);

            _dbcontext.SaveChanges();
        }
    }
}
