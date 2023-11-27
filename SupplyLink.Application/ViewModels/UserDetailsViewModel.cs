using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        private object fullName;
        private string name;
        private string document;
        private string login;
        private SupplierStatusEnum status;
        private DateTime createAt;

        public UserDetailsViewModel(string fullName, string email, DateTime createdAt)
        {
            FullName = fullName;
            Email = email;
            CreatedAt = createdAt;
        }

        public UserDetailsViewModel(object fullName, string name, string document, string login, SupplierStatusEnum status, DateTime createAt)
        {
            this.fullName = fullName;
            this.name = name;
            this.document = document;
            this.login = login;
            this.status = status;
            this.createAt = createAt;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; }
    }
}
