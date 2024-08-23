using KooBits.MicroServices.OrderServices.Models;

namespace KooBits.MicroServices.OrderServices.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddUserOrderAsync(Order order);
    }
}
