using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IUserDal
    {
        // Getters
        UserModel? Login(string email, string password);

        // Actions
        UserModel? RegisterUser(UserModel User);
        // void DeleteUser(string UserEmail);
    }
}
