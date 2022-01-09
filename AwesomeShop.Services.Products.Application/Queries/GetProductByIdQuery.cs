using System;
using AwesomeShop.Services.Products.Application.Dtos.ViewModels;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDetailsViewModel>
    {
        public GetProductByIdQuery(Guid id)
        {
            this.Id = id;

        }
        public Guid Id { get; private set; }
    }
}