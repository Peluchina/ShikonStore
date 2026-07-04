using Microsoft.AspNetCore.Mvc;
using ShikonStore.Application.Commands;
using ShikonStore.Application.DTOs;
using ShikonStore.Application.Parameters;
using ShikonStore.Application.Queries;

namespace ShikonStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductCreateCommandHandler _createHandler;
        private readonly ProductUpdateCommandHandler _updateHandler;
        private readonly ProductUpdateStatusCommandHandler _updateStatusHandler;
        private readonly ProductDeleteCommandHandler _deleteHandler;
        private readonly ProductGetListQueryHandler _getListHandler;
        private readonly ProductGetXIdQueryHandler _getXIdHandler;

        public ProductController(
            ProductCreateCommandHandler createHandler,
            ProductUpdateCommandHandler updateHandler,
            ProductUpdateStatusCommandHandler updateStatusHandler,
            ProductDeleteCommandHandler deleteHandler,
            ProductGetListQueryHandler getListHandler,
            ProductGetXIdQueryHandler getXIdHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _updateStatusHandler = updateStatusHandler;
            _deleteHandler = deleteHandler;
            _getListHandler = getListHandler;
            _getXIdHandler = getXIdHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetListResponse>>> GetAll()
        {
            var result = await _getListHandler.HandleAsync(new ProductGetListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetXIdResponse>> GetById(int id)
        {
            var query = new ProductGetXIdQuery 
            { 
                Parameters = new ProductGetXIdParams { IdProducto = id } 
            };
            var result = await _getXIdHandler.HandleAsync(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCreateResponse>> Create([FromBody] ProductCreateRequest request)
        {
            var command = new ProductCreateCommand { Request = request };
            var result = await _createHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetById), new { id = result.IdProducto }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] ProductUpdateRequest request)
        {
            var command = new ProductUpdateCommand 
            { 
                Parameters = new ProductUpdateParams { IdProducto = id }, 
                Request = request 
            };
            var result = await _updateHandler.HandleAsync(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<bool>> UpdateStatus(int id, [FromBody] ProductUpdateStatusRequest request)
        {
            var command = new ProductUpdateStatusCommand 
            { 
                Parameters = new ProductUpdateStatusParams { IdProducto = id }, 
                Request = request 
            };
            var result = await _updateStatusHandler.HandleAsync(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var command = new ProductDeleteCommand 
            { 
                Parameters = new ProductDeleteParams { IdProducto = id } 
            };
            var result = await _deleteHandler.HandleAsync(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
