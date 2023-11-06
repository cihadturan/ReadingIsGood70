using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood70.BusinessLayer.Contracts;
using ReadingIsGood70.BusinessLayer.Extensions;
using ReadingIsGood70.BusinessLayer.RequestModels.Order;
using ReadingIsGood70.BusinessLayer.ResponseModels.Base;
using ReadingIsGood70.BusinessLayer.ResponseModels.Order;
using ReadingIsGood70.Utils;
using ReadingIsGood70.Utils.Identity;

namespace ReadingIsGood70.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        [Consumes(Constants.MimeType.Json)]
        [ProducesResponseType(typeof(ListResponse<OrderListItemResponse>), 200)]
        [ProducesResponseType(typeof(ListResponse<OrderListItemResponse>), 401)]
        public Task<ListResponse<OrderListItemResponse>> GetList(CancellationToken cancellationToken)
        {
            var response = new ListResponse<OrderListItemResponse>(this.HttpContext.TraceIdentifier);
            
            try
            {
                response.Model = this._orderService.GetOrderList(HttpContext.User.GetUserId(), cancellationToken);
            }
            catch (Exception e)
            {
                response.SetError(e);
                response.Model = null;
            }

            return Task.FromResult(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Consumes(Constants.MimeType.Json)]
        [ProducesResponseType(typeof(SingleResponse<OrderDetailResponse>), 200)]
        [ProducesResponseType(typeof(SingleResponse<OrderDetailResponse>), 401)]
        public async Task<SingleResponse<OrderDetailResponse>> GetSpecific(string id, CancellationToken cancellationToken)
        {
            var response = new SingleResponse<OrderDetailResponse>(this.HttpContext.TraceIdentifier);

            try
            {
                response.Model = await this._orderService.GetOrderDetail(HttpContext.User.GetUserId(), Guid.Parse(id), cancellationToken);
            }
            catch (Exception e)
            {
                response.SetError(e);
                response.Model = null;
            }

            return response;
        }

        [HttpPost]
        [Authorize]
        [Consumes(Constants.MimeType.Json)]
        [ProducesResponseType(typeof(ListResponse<ProductQuantityData>), 200)]
        [ProducesResponseType(typeof(ListResponse<ProductQuantityData>), 401)]
        public async Task<ListResponse<ProductQuantityData>> Order(OrderRequest request, CancellationToken cancellationToken)
        {
            var response = new ListResponse<ProductQuantityData>(this.HttpContext.TraceIdentifier);

            try
            {
                request.ValidateAndThrow();

                response.Model = await _orderService.Order(HttpContext.User.GetUserId(), request, cancellationToken)
                        .ConfigureAwait(false)
                    ;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                response.Model = null;
            }

            return response;
        }
    }
}