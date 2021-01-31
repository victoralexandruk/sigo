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
        private readonly IRepository<AppUser> _userRepository;

        public IndexController(IConfiguration config, IRepository<AppUser> userRepository)
        {
            _config = config;
            _userRepository = userRepository;
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
        public object Login(LoginInfo loginInfo)
        {
            var user = _userRepository.GetAll().Where(u => u.Username == loginInfo.Username && u.Password == loginInfo.Password).FirstOrDefault();
            if (user != null)
            {
                return new { Token = TokenHelper.CreateToken(user, _config["Jwt:Secret"]) };
            }
            else
            {
                return null;
            }
        }
    }
}
