using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Models.Orders
{
    public class CreditCardAuthorizationRequest
    {

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string Cvv2 { get; set; }
        public decimal  Amount { get; set; }
    }

}
