using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Visklineo.Business.Helpers;
using Visklineo.Business.ViewModels;
using Visklineo.Business.ViewModels.User;
using Visklineo.Business.ViewModels.User.User;
using Visklineo.Database;

namespace Visklineo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<bool> SignUp([FromBody] SignUpModel model)
        {
            var result = new IdentityResult();
            var user = new ApplicationUser {FirstName = model.FirstName, LastName = model.LastName, UserName = model.EmailId, Email = model.EmailId };
            result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<object> Login([FromBody] SignInModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Token + AppSettings.Token + AppSettings.Token));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
                    new Claim("Id", Convert.ToString(user.Id)),
                    new Claim("Name",user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };
                var token = new JwtSecurityToken(
                    issuer: AppSettings.Issuer,
                    audience: AppSettings.Issuer,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);
                    var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

                return new Response
                {
                    model = token,
                    Message = "",
                    Status = true
                };
            }
            return Unauthorized();
        }
    }

}
