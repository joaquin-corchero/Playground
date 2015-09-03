using Playground.Async.Domain.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Playground.Async.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductQueryRepository _productQueryRepository;

        public ProductController(IProductQueryRepository productRepository)
        {
            _productQueryRepository = productRepository;
        }

        // GET: AsyncTest
        public async Task<ActionResult> Index()
        {
            return View(await _productQueryRepository.GetAll());
        }
    }
}