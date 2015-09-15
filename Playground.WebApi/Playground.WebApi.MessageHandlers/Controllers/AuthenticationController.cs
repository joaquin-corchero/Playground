using System.Web.Http;

namespace Playground.WebApi.MessageHandlers.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiController
    {
        /// <summary>
        /// Have a look at the Handlers.NaiveAuthenticationHandler and the App_start/WebApiConfig for the handler registration.
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IHttpActionResult GetAuth()
        {
            return Ok(new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            });
        }

        [Route("secured")]
        [Authorize]
        public IHttpActionResult GetSecured()
        {
            return Ok(new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            });
        }
    }
}
