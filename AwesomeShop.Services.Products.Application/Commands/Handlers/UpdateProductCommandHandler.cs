using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            product.Update(request.Description, request.Price, request.Category.ToValueObject());

            await _repository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}