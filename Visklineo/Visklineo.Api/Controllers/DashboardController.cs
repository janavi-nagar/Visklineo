using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Visklineo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : BaseApiController
    {
        public DashboardController()
        {
        }

        [HttpGet]
        public int Get()
        {
            var i = 0;
            return i;
        }
    }

}
