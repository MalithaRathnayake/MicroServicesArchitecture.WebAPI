using KooBits.Domain.Models;
using KooBits.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KooBits.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly OrderDBContext _context;

        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }
          
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task AddUserOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
