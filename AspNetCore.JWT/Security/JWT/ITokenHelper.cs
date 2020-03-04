using Business.Model.Auth;

namespace AspNetCore.JWT.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(LoginOutModel user);
    }
}
