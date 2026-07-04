using ShikonStore.Application.DTOs;
using ShikonStore.Application.Parameters;

namespace ShikonStore.Application.Commands
{
    public class ProductUpdateCommand
    {
        public ProductUpdateParams Parameters { get; set; } = null!;
        public ProductUpdateRequest Request { get; set; } = null!;
    }
}
