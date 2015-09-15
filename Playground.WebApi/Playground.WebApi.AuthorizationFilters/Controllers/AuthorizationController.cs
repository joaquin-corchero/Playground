using Playground.WebApi.AuthorizationFilters.Filters;
using System.Web.Http;

namespace Playground.WebApi.AuthorizationFilters.Controllers
{
    [NaiveAuthorizationFilter]
    [RoutePrefix("api/auth")]
    public class AuthorizationController : ApiController
    {

        [Route("")]
        public IHttpActionResult GetAuth()
        {
            return Ok(
                new
                {
                    User.Identity.IsAuthenticated,
                    User.Identity.Name
                });
        }

        [Route("secured")]
        [Authorize]
        public IHttpActionResult GetWithAuth()
        {
            return Ok(
                new
                {
                    User.Identity.IsAuthenticated,
                    User.Identity.Name
                });
        }
    }
}