using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
            using (SHA256 sha256 = SHA256.Create())
            {
                var securityKey = new SymmetricSecurityKey(sha256.ComputeHash(Encoding.UTF8.GetBytes(_config["Jwt:Secret"])));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, loginInfo.Username),
                        new Claim(ClaimTypes.Role, ""),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
