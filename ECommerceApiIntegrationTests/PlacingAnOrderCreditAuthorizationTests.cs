using ECommerceApi;
using ECommerceApi.HttpClients;
using ECommerceApi.Models.Orders;
using ECommerceApiIntegrationTests.OrdersResource;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiIntegrationTests
{
    public class PlacingAnOrderCreditAuthorizationTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        private readonly Mock<IUsBankHttpClient> _stubbedHttpClient;
        public PlacingAnOrderCreditAuthorizationTests(WebApplicationFactory<Startup> factory)
        {
            _stubbedHttpClient = new Mock<IUsBankHttpClient>();

          

            _stubbedHttpClient.Setup(b => b.AuthorizeAsync(It.IsAny<CreditCardAuthorizationRequest>())).Throws(new HttpRequestException());
            _factory = factory;

            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(IUsBankHttpClient)
                        );
                    services.Remove(descriptor);
                    services.AddSingleton<IUsBankHttpClient>((_) => _stubbedHttpClient.Object);
                  
                    

                });
            }).CreateClient();
           
        }

        [Fact]
        public async Task WhenCreditCardApiIsDownAddAMessageInAuthorizaitonCode()
        {
            var request = await _client.PostAsJsonAsync("/orders", OrdersTestData.ValidOrder);

            var response = await request.Content.ReadAsAsync<StandardOrderResponse>();


             Assert.Equal("Credit Card Authorizaiton Pending", response.creditCardAuthorization);
        }
    }
}
