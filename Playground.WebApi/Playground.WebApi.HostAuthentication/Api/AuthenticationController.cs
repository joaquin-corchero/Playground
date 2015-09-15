using System.Web.Http;

namespace Playground.WebApi.HostAuthentication.Api
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        [Route("")]
        public IHttpActionResult GetNoAuth()
        {
            return Ok(new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            });
        }

        [Route("secured")]
        [Authorize]
        public IHttpActionResult GetAuth()
        {
            return Ok(new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            });
        }
    }
}