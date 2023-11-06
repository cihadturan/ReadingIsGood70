using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ReadingIsGood70.BusinessLayer.Contracts;
using ReadingIsGood70.BusinessLayer.Extensions;
using ReadingIsGood70.BusinessLayer.RequestModels.Product;
using ReadingIsGood70.BusinessLayer.ResponseModels.Base;
using ReadingIsGood70.BusinessLayer.ResponseModels.Order;
using ReadingIsGood70.BusinessLayer.ResponseModels.Product;
using ReadingIsGood70.Utils;

namespace ReadingIsGood70.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        [Consumes(Constants.MimeType.Json)]
        [ProducesResponseType(typeof(ListResponse<ProductResponse>), 200)]
        [ProducesResponseType(typeof(ListResponse<ProductResponse>), 401)]
        public Task<ListResponse<ProductResponse>> GetList()
        {
            var response = new ListResponse<ProductResponse>(HttpContext.TraceIdentifier);
            
            try
            {
                response.Model = _productService.GetAvailableProductList();
            }
            catch (Exception e)
            {
                response.SetError(e);
                response.Model = null;
            }

            return Task.FromResult(response);
        }

        [HttpPost("generate-products")]
        [Authorize]
        [Consumes(Constants.MimeType.Json)]
        [ProducesResponseType(typeof(PostResponse), 200)]
        [ProducesResponseType(typeof(PostResponse), 401)]
        public async Task<PostResponse> GenerateProducts()
        {
            var response = new PostResponse(HttpContext.TraceIdentifier);

            try
            {
                await _productService.CreateProductOrIncreaseStock();
            }
            catch (Exception e)
            {
                response.SetError(e);
            }

            return response;
        }
    }
}
