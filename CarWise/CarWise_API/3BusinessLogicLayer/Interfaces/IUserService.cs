using _1CommonInfrastructure.Models;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Login(string email, string password);
        Task<UserModel> RegisterUser(UserModel user);

    }
}
