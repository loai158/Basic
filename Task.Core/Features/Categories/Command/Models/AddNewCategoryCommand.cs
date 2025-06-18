using MediatR;
using Task.Core.ResponseWrapper;

namespace Task.Core.Features.Categories.Command.Models
{
    public class AddNewCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }

    }
}
