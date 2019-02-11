using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebAPITokenAutentication.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is " + DateTime.Now.ToLongDateString());
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAutentication()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok("Hello " + identity.Name);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/autorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                                        .Select(c => c.Value);

            return Ok("Hello " + identity.Name + " Roles: " + string.Join(",", roles.ToList()));
        }
    }
}
