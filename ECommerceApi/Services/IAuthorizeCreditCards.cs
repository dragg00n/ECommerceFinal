using ECommerceApi.Models.Orders;
using System.Threading.Tasks;

namespace ECommerceApi
{
    public interface IAuthorizeCreditCards
    {
        Task<CreditCardAuthorizationResponse> AuthorizeAsync(CreditCardAuthorizationRequest creditCardInfo);
    }
}