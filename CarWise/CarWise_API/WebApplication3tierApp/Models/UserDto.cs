using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class UserDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }

    public static class UserDtoMapExtensions
    {
        public static UserDto ToUserDto(this UserModel src)
        {
            var dst = new UserDto();
            dst.UserEmail = src.UserEmail;
            dst.UserFirstName = src.UserFirstName;
            dst.UserLastName = src.UserLastName;
            return dst;
        }

        public static UserModel ToUserModel(this UserDto src)
        {
            var dst = new UserModel();
            dst.UserEmail = src.UserEmail;
            dst.UserPassword = src.UserPassword;
            dst.UserFirstName = src.UserFirstName;
            dst.UserLastName = src.UserLastName;
            return dst;
        }
    }
}
