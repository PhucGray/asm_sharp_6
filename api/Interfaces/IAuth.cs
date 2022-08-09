using share.Models;
using share.Models.UI;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IAuth
    {
        Task<dynamic> SignIn(SignInModel signInData);
        Task<dynamic> SignUp(UserModel userData);
        Task<dynamic> GetProfile(string token);
        //Task<dynamic> GetProfile(string token);
        //Task<dynamic> UpdatePassword(string token, UpdatePasswordReqModel updatePasswordReq);
    }
}
