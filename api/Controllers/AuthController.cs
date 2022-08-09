using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using share.Models;
using share.Models.UI;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<dynamic> SignIn(SignInModel signInData)
        {
            return await _auth.SignIn(signInData);
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<dynamic> SignUp(UserModel signUpData)
        {
            return await _auth.SignUp(signUpData);
        }

        //[HttpGet]
        //[Route("profile")]
        //public async Task<dynamic> GetProfile([FromHeader] string authorization)
        //{
        //    if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
        //    {
        //        var token = headerValue.Parameter;

        //        return await _auth.GetProfile(token);
        //    }

        //    return new { Success = false, Message = "Vui lòng cung cấp token" };
        //}

        //[HttpPut]
        //[Route("update-password")]
        //public async Task<dynamic> UpdatePassword([FromHeader] string authorization
        //                                        , UpdatePasswordReqModel updatePasswordReq)
        //{
        //    if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
        //    {
        //        var token = headerValue.Parameter;

        //        return await _auth.UpdatePassword(token, updatePasswordReq);
        //    }

        //    return new { Success = false, Message = "Vui lòng cung cấp token" };
        //}
    }
}
