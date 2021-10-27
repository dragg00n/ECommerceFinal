using ECommerceApi.Models.Orders;
using System.Threading.Tasks;

namespace ECommerceApi.HttpClients
{
    public interface IUsBankHttpClient
    {
        Task<CreditCardAuthorizationResponse> AuthorizeAsync(CreditCardAuthorizationRequest creditCardInfo);
    }
}