using ECommerceApi.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApiIntegrationTests.OrdersResource
{
    public static class OrdersTestData
    {
        public static OrderResponse ValidResponse = new OrderResponse
        {
            Message = "Groovy!",
            AmountCharged = Decimal.MaxValue,
            CreditCardAuthorization = "Awesome!",
            OrderNumber = "99",
            ShipDate = "Tomorrow",
            Shipping = 19.99M,
            Tax = 3.75M
        };

        public static OrderRequest ValidOrder = new OrderRequest
        {
            name = "Bob Smith",
            address = "1212 Orange St",
            city = "Akron",
            state = "OH",
            zip = "44319",
            creditCardInfo = new Creditcardinfo
            {
                number = "4417-1234-5678-9113",
                expiration = "06/22",
                cvv2 = "973"
            },
            items = new List<Item>
                {
                    new Item { id="1", name="Beer", price=6.99M, qty=1}
                }


        };

    }


    public class StandardOrderResponse
    {
        public string orderNumber { get; set; }
        public string message { get; set; }
        public string shipDate { get; set; }
        public decimal amountCharged { get; set; }
        public string creditCardAuthorization { get; set; }
        public decimal tax { get; set; }
        public decimal shipping { get; set; }
    }

}
