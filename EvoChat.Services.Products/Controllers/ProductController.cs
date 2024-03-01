using EvoChat.Services.Products.Dto;
using EvoChat.Services.Products.Repository;
using EvoChat.Shared;
using EvoChat.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoChat.Services.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository; 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = productDtos, Message = ResponseMessages.msgGotSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(Guid Id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(Id);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = productDto, Message = ResponseMessages.msgGotSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }


        [HttpPost]
        //[Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = model, Message = "Product" +ResponseMessages.msgCreationSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }


        [HttpPut]
        //[Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = model, Message = "Product" + ResponseMessages.msgUpdationSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(Guid Id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(Id);
                return Ok(new ResponseDto { status = isSuccess, StatusCode = StatusCodes.Status200OK, data = null, Message = "Product" + ResponseMessages.msgDeletionSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }
    }
}
