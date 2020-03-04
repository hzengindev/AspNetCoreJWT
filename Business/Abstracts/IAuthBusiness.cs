using Business.Model.Auth;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthBusiness
    {
        Task<LoginOutModel> Login(LoginInModel value);
    }
}
