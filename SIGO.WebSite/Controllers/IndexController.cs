using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIGO.Common;
using SIGO.Domain.Common;
using SIGO.WebSite.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.WebSite.Controllers
{
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IConfiguration _config;

        public IndexController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("Info")]
        public object Info()
        {
            return new
            {
                WebApi = new
                {
                    Normas = _config["WebApi:Normas"],
                    Consultorias = _config["WebApi:Consultorias"]
                }
            };
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public string Login(LoginInfo loginInfo)
        {
            return TokenHelper.CreateToken(new AppUser
            {
                Username = loginInfo.Username
            }, _config["Jwt:Secret"]);
        }
    }
}
