using SupplyLink.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyLink.Application.ViewModels
{
    public class UserViewModel
    {
        private string login;
        private SupplierStatusEnum status;
        private DateTime createAt;

        public UserViewModel(object full, string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public UserViewModel(string fullName, string email, DateTime createdAt)
        {
            FullName = fullName;
            Email = email;
            CreatedAt = createdAt;
        }

        public UserViewModel(object full, string fullName, string email, string login, SupplierStatusEnum status, DateTime createAt) : this(full, fullName, email)
        {
            this.login = login;
            this.status = status;
            this.createAt = createAt;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; }
    }
}
