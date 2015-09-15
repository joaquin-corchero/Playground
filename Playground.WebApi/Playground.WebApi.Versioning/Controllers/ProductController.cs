using Playground.WebApi.Versioning.Filters;
using Playground.WebApi.Versioning.Repositories;
using System.Web.Http;

namespace Playground.WebApi.Versioning.Controllers
{
    //http://www.troyhunt.com/2014/02/your-api-versioning-is-wrong-which-is.html
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository = new ProductReposotory();

        [VersionedRoute("api/products/", 1)]
        [Route("api/v1/products")]
        public IHttpActionResult GetProductsV()
        {
            return Ok(_productRepository.GetAll());
        }

        [VersionedRoute("api/products/", 2)]
        [Route("api/v2/products")]
        public IHttpActionResult GetProductsV2()
        {
            return Ok(_productRepository.GetAllExtended());
        }

    }
}