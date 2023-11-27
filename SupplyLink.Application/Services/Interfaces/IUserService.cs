using SupplyLink.Application.InputModels;
using SupplyLink.Application.ViewModels;

namespace SupplyLink.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll(string query);
        UserDetailsViewModel GetById(int id);
        int Create(NewUserInputModel inputModel);

        void Update(UpdateUserInputModel inputModel);

        void Delete(int id);
    }
}
