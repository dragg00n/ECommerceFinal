using ECommerceApi;
using ECommerceApi.Models.Orders;
using ECommerceApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiUnitTests
{
    public class StandardOrderProcessorRequestsTests
    {

        [Fact]
        public async Task UsesTheCreditCardAuthorizationService()
        {
            // Given
            var stubbedCreditService = new Mock<IAuthorizeCreditCards>();
            stubbedCreditService.Setup(c => c.AuthorizeAsync(It.IsAny<CreditCardAuthorizationRequest>()))
                .Returns(Task.FromResult(new CreditCardAuthorizationResponse { AuthorizationCode = "Groovy" }));
            var sut = new StandardOrderProcessor(stubbedCreditService.Object);
            var orderToProcess = new OrderPostRequest { Name="Joe Schmidt", Items = new List<Item>(),CreditCardInfo = new Creditcardinfo() };

            // When
            var response = await sut.ProcessOrderAsync(orderToProcess);

            // Then
            Assert.Equal("Groovy",response.CreditCardAuthorization);


        }
    }
}
