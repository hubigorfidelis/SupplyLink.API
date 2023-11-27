using System;
using System.Collections.Generic;

namespace SupplyLink.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
        }

        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDate { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public bool Active { get; set; }
        public byte[] PasswordHash { get;  set; }
        public byte[] PasswordSalt { get;  set; }
        public string Password { get; set; }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;

        }

        public void Update(string fullName, string email, bool active, DateTime birthDate)
        {
            throw new NotImplementedException();
        }
    }


}

