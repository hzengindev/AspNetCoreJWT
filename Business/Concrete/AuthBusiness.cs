using Business.Abstracts;
using Business.Model.Auth;
using Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthBusiness : IAuthBusiness
    {
        public static readonly List<UserTable> USERS = new List<UserTable> { 
            new UserTable {
                Id = new Guid("CED99E2A-0FD5-43EF-A6B9-80EDD73117FC"),
                Username = "testuser",
                Name = "Test User",
                PasswordSalt = "hKA+0jNe8W4PHYUG36A1IiRzYh2lGTSRlp8jof2/hUZCw/4GoHdhYzB9u/fu9FEYdubdy+jxvhGpMdpStUx7ZvwOD3MZruXoTuJAjpvDqVNzc+DU/kUxBqLWaW36XM/HeBuJ3VYeDqvRjmH7xA6P2Ama3F6Nv/NVjoaGlY4oHys=",
                PasswordHash = "009HFx51Uj6Fxu5kwexil3S2GXHjUHlfzFT1XHqhGZjgmxmu56bXCfrc3EmaUkWHL76ISjQygYD/Rny0Mplp3g=="
                //Password = 123456
            }
        };

        public async Task<LoginOutModel> Login(LoginInModel value)
        {
            return await Task.Run<LoginOutModel>(() => {
                var returnValue = new LoginOutModel();

                //DB context üzerinden sorgulara yapılarak kontroller sağlanabilir

                var user = USERS.FirstOrDefault(z => z.Username == value.Username);
                if (user == null)
                {
                    returnValue.ErrorMessage = "User not found!";
                    returnValue.Success = false;
                    return returnValue;
                }

                if (!HashingHelper.VerifyPasswordHash(value.Password, user.PasswordHash, user.PasswordSalt))
                {
                    returnValue.ErrorMessage = "Password is wrong!";
                    returnValue.Success = false;
                    return returnValue;
                }

                returnValue.Id = user.Id;
                returnValue.Name = user.Name;
                returnValue.Username = user.Username;

                return returnValue;
            });
        }
    }

    public class UserTable
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
