using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;
using BCrypt.Net;

namespace _3BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDal _UserDal;
        public UserService(IUserDal UserDal)
        {
            _UserDal = UserDal;
        }

        public async Task<UserModel> Login(string email, string password)
        {
            return _UserDal.Login(email, password);
        }

        public async Task<UserModel> RegisterUser(UserModel User)
        {
            return _UserDal.RegisterUser(User);
        }
    }
}
