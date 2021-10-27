using ECommerceApi.CustomValidators;
using ECommerceApi.Filters;
using ECommerceApi.Models.Orders;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{

    public class OrdersController : ControllerBase
    {
        private readonly IProcessOrders _orderProcessor;

        public OrdersController(IProcessOrders orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        [HttpPost("/orders")]
        [ValidateModel]
        public async Task<ActionResult> PlaceOrder([FromBody] OrderPostRequest request)
        {
            OrderResponse response = await _orderProcessor.ProcessOrderAsync(request);
            return StatusCode(201, response);
        }
    }
}
