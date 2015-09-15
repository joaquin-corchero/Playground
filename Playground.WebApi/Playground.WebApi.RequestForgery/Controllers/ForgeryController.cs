using System.Web.Http;


namespace Playground.WebApi.RequestForgery.Controllers
{
    [RoutePrefix("api/forgery")]
    public class ForgeryController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post()
        {
            return Ok("The request was successful!");
        }
    }
}
