using Playground.Async.Application.ViewModels;
using Playground.Async.Domain.Repositories;
using Playground.Async.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Async.Application.Services
{
    public interface IProductControllerService
    {

    }

    public class ProductControllerService : IProductControllerService
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductControllerService(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public ProductControllerService() : this(new ProductRepository()) { }

        public async Task<List<ProductViewModel>> GetAll()
        {
            return ProductViewModel.GetFromProducts(await _productQueryRepository.GetAll());
        }
    }
}