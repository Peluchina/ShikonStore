using ShikonStore.Application.DTOs;
using ShikonStore.Application.Parameters;

namespace ShikonStore.Application.Commands
{
    public class ProductUpdateStatusCommand
    {
        public ProductUpdateStatusParams Parameters { get; set; } = null!;
        public ProductUpdateStatusRequest Request { get; set; } = null!;
    }
}
