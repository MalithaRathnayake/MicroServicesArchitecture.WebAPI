using KooBits.MicroServices.OrderServices.Models;

namespace KooBits.MicroServices.OrderServices.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task AddOrderAsync(Order order);
    }
}

 

