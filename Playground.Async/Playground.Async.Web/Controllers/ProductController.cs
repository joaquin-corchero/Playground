using Playground.Async.Web.Infrastructure.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Playground.Async.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: AsyncTest
        public async Task<ActionResult> Index()
        {
            return View(await _productRepository.GetAll());
        }
    }
}