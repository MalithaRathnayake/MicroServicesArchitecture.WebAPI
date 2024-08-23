namespace KooBits.Domain.Models
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddUserOrderAsync(Order order);
    }
}
