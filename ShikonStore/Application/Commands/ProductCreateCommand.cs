using ShikonStore.Application.DTOs;

namespace ShikonStore.Application.Commands
{
    public class ProductCreateCommand
    {
        public ProductCreateRequest Request { get; set; } = null!;
    }
}
