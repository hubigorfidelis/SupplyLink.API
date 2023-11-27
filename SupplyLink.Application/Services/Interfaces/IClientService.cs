using SupplyLink.Application.InputModels;
using SupplyLink.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Services.Interfaces
{
    public interface IClientService
    {
        List<ClientViewModel> GetAll(string query);

        ClientDetailsViewModel GetById(int id);

        int Create(NewClientInputModel inputModel);

        void Update(UpdateClientInputModel inputModel);

        void Delete(int id);

    }
}
