using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using LoginApi.Models;
using LoginApi.Helpers;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ProfileHelper proHelp = new ProfileHelper();
        private IConfiguration _config;
        private UserHelper userHel = new UserHelper();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            UserModel user = await Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                UserModel userAuth = new UserModel()
                {
                    user = user.user,
                    email = user.email,
                    role = user.role,
                    app = user.app
                };
                response = Ok(new { token = tokenString, userAuth});
            }

            return response;
        }

        private string BuildToken(UserModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.user),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Typ, user.app),
                new Claim(JwtRegisteredClaimNames.Acr, user.role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserModel> Authenticate(LoginModel login)
        {
            UserModel user = null;
            if (login != null)
            {
                user = await userHel.GetUserByUserPassword(login.username, login.password);
            }
            return user;
        }

        [HttpGet, Authorize]
        public async Task<IEnumerable<ProfileModel>> GetProfileAll()
        {
            var all = proHelp.GetProfileList();
            return await all;
        }

        [HttpPost("getprofile"), Authorize]
        public async Task<ProfileModel> GetProfileByEmail(string email)
        {
            //string email = "chingchana@gmail.com";
            var profile = proHelp.GetProfileByEmail(email);
            return await profile;
        }
    }
}