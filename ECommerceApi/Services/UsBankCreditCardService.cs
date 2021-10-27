using ECommerceApi.HttpClients;
using ECommerceApi.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class UsBankCreditCardService : IAuthorizeCreditCards
    {
        private readonly IUsBankHttpClient _client;

        public UsBankCreditCardService(IUsBankHttpClient client)
        {
            _client = client;
        }

        public async Task<CreditCardAuthorizationResponse> AuthorizeAsync(CreditCardAuthorizationRequest creditCardInfo)
        {
            try
            {
                return await _client.AuthorizeAsync(creditCardInfo);
            }
            catch (HttpRequestException )
            {
                

                return new CreditCardAuthorizationResponse { AuthorizationCode = "Credit Card Authorizaiton Pending" };
            }
        }
    }
}
