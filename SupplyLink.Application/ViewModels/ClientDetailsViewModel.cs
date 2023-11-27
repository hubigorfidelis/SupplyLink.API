using SupplyLink.Core.Entities;
using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.ViewModels
{
    public class ClientDetailsViewModel
    {
        public ClientDetailsViewModel(int id, string name, string document, string login, ClientStatusEnum status, DateTime createAt)
        {
            Id = id;
            Name = name;
            Document = document;
            Login = login;
            Status = status;
            CreateAt = createAt;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Login { get; private set; }
        public ClientStatusEnum Status { get; private set; }
        public DateTime CreateAt { get; private set; }

        public List<ClientAdress>? Adresses { get; private set; }
        public List<ClientContact>? Contacts { get; private set; }
    }
}
