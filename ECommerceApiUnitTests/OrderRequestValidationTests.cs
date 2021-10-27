using ECommerceApi.Models.Orders;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ECommerceApi.Controllers;
using ECommerceApi.Filters;
using ECommerceApi.CustomValidators;

namespace ECommerceApiUnitTests
{
    public class OrderRequestValidationTests
    {
        [Fact()]
        public void OrderRequestHasTheCorrectValidationAttributes()
        {
            var maxLengthOnName = Helpers.GetPropertyAttributeValue<OrderPostRequest, string, MaxLengthAttribute, int>(p => p.Name, attr => attr.Length);

            Assert.Equal(100, maxLengthOnName);
            Assert.True(Helpers.HasAttribute<OrderPostRequest, RequiredAttribute>(c => c.Name));
            Assert.True(Helpers.HasAttribute<Creditcardinfo, CreditCardLuhnCheckAttribute>(c => c.Number));
        }

        [Fact]
        public void OrderPostValidatesModel()
        {
            var method = typeof(OrdersController).GetMethods()
                 .SingleOrDefault(x => x.Name == nameof(OrdersController.PlaceOrder));

            var attribute = method?.GetCustomAttributes(typeof(ValidateModelAttribute), true)
               .Single() as ValidateModelAttribute;

            Assert.NotNull(attribute);
        }

        
    }
}
