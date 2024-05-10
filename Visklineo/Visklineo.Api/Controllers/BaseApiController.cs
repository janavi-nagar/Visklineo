using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Visklineo.Business.Helpers;
using Visklineo.Business.ViewModels.User;
using Visklineo.Database;

namespace Visklineo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : Controller
    {
       
        public BaseApiController()
        {
           
        }

    }
}
