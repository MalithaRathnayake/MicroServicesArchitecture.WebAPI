using KooBits.Domain.Models;

namespace KooBits.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task AddOrderAsync(Order order);
    }
}

 

