using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.JWT.Base;
using AspNetCore.JWT.Models.Auth;
using AspNetCore.JWT.Security.JWT;
using Business.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.JWT.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        IAuthBusiness authBusiness;
        ITokenHelper tokenHelper;

        public AuthController(IAuthBusiness _authBusiness, ITokenHelper _tokenHelper)
        {
            this.authBusiness = _authBusiness;
            this.tokenHelper = _tokenHelper;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Create([FromBody]TokenRequestModel value)
        {
            if (!ModelState.IsValid)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                foreach (var item in ModelState)
                    if (item.Value.Errors.Any())
                        errors.Add(item.Key, string.Join("; ", item.Value.Errors.Select(x => x.ErrorMessage)));
                return Error("Parameter error", null, errors);
            }

            var loginResult = await authBusiness.Login(new Business.Model.Auth.LoginInModel
            {
                Username = value.Username,
                Password = value.Password
            });

            if (!loginResult.Success)
                return Error(loginResult.ErrorMessage, loginResult.ErrorCode);

            var returnValue = tokenHelper.CreateToken(loginResult);
            return Success(returnValue);
        }
    }
}