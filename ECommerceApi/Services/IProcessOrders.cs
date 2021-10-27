using ECommerceApi.Models.Orders;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public interface IProcessOrders
    {
        Task<OrderResponse> ProcessOrderAsync(OrderPostRequest request);
    }
}