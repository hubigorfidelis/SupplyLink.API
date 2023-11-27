using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Application.ViewModels;
using SupplyLink.Core.Entities;
using SupplyLink.Infra.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SupplyLink.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly SupplyLinkDbContext _dbcontext;

        public UserService(SupplyLinkDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {

            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate,inputModel.Password);
            if (inputModel.Password != null) 
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputModel.Password));
                byte[] passwordSalt = hmac.Key;

                user.AlterarSenha(passwordHash, passwordSalt);
                
            }
            
            _dbcontext.Users.Add(user);

            _dbcontext.SaveChanges();
            return user.Id;
        }
        public void Delete(int id)
        {
            var user = _dbcontext.Users.SingleOrDefault(supplier => supplier.Id == id);
            if (user == null)
            {
                throw new Exception("Not Found");
            }
           
            _dbcontext.SaveChanges();
        }

        public List<UserViewModel> GetAll(string query)
        {
            var suppliers = _dbcontext.Users;

            var supplierViewModel = suppliers
                .Select(p => new UserViewModel(p.FullName, p.Email, p.CreatedAt))
                .ToList();

            return supplierViewModel;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbcontext.Users.SingleOrDefault(user => user.Id == id);

            var userDetaisViewModel = new UserDetailsViewModel(
                user.FullName,
                user.Email,
                user.CreatedAt
                );

            return userDetaisViewModel;
        }

        public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbcontext.Users.SingleOrDefault(supplier => supplier.Id == inputModel.Id);

            user.Update(inputModel.FullName, inputModel.Email, inputModel.Active,inputModel.BirthDate) ;

            _dbcontext.SaveChanges();
        }

    }
}
