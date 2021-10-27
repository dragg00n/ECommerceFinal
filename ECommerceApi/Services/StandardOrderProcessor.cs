using ECommerceApi.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class StandardOrderProcessor : IProcessOrders
    {

        private readonly IAuthorizeCreditCards _creditCardService;

        public StandardOrderProcessor(IAuthorizeCreditCards creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public async Task<OrderResponse> ProcessOrderAsync(OrderPostRequest request)
        {
            var response = new OrderResponse();

            // Homework - extract this to another service.
            var subtotal = request.Items.Select(item => item.Price * item.Qty).Sum();
            var tax = subtotal * .075M;
            var shipping = 10.00M;

            var authorizationRequest = new CreditCardAuthorizationRequest
            {
                NameOnCard = request.Name,
                CardNumber = request.CreditCardInfo.Number,
                Cvv2 = request.CreditCardInfo.Cvv2,
                Expiration = request.CreditCardInfo.Expiration,
                Amount = subtotal + tax + shipping
               
            };
            CreditCardAuthorizationResponse auth = 
                await _creditCardService.AuthorizeAsync(authorizationRequest);

            response.CreditCardAuthorization = auth.AuthorizationCode;
            return response;
        }
    }
}
