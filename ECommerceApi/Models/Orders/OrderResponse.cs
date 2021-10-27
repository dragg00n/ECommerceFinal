using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Models.Orders
{
    public class OrderResponse
    {

        public string OrderNumber { get; set; }
        public string Message { get; set; }
        public string ShipDate { get; set; }
        public decimal  AmountCharged { get; set; }
        public string CreditCardAuthorization { get; set; }
        public decimal  Tax { get; set; }
        public decimal  Shipping { get; set; }
    }

}
