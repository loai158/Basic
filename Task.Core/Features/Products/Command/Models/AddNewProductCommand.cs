using MediatR;
using Microsoft.AspNetCore.Http;
using Task.Core.ResponseWrapper;

namespace Task.Core.Features.Products.Command.Models
{
    public class AddNewProductCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
