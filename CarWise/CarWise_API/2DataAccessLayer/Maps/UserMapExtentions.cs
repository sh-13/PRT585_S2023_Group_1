using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class UserMapExtensions
    {
        public static UserModel ToUserModel(this User src)
        {
            var dst = new UserModel();

            dst.UserEmail = src.UserEmail;
            // dst.UserPassword = src.UserPassword;
            dst.UserFirstName = src.UserFirstName;
            dst.UserLastName = src.UserLastName;

            return dst;
        }

        public static User ToUser(this UserModel src, User dst = null)
        {
            if (dst == null)
            {
                dst = new User();
            }

            dst.UserEmail = src.UserEmail;
            dst.UserPassword = src.UserPassword;
            dst.UserFirstName = src.UserFirstName;
            dst.UserLastName = src.UserLastName;

            return dst;
        }
    }
}
