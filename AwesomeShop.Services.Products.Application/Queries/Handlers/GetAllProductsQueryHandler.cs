using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Services.Products.Application.Dtos.ViewModels;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            return products
                .Select(p => new ProductViewModel(p.Id, p.Title))
                .ToList();
        }
    }
}