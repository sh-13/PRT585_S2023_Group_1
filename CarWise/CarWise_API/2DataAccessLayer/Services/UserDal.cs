using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using Microsoft.EntityFrameworkCore;

namespace _2DataAccessLayer.Services
{
    public class UserDal : IUserDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public UserDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }

        public UserModel RegisterUser(UserModel User)
        {
            var newUser = User.ToUser();
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return User;
        }

        public UserModel? Login(string email, string password)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserEmail == email);
            if (user != null && user.UserPassword == password)
            {
                return user.ToUserModel();
            }
            return null;
        }
    }
}
