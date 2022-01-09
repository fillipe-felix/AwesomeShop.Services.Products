using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Services.Products.Core.Entities;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _repository;
        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ToEntity();

            await _repository.AddAsync(product);

            return product.Id;
        }
    }
}