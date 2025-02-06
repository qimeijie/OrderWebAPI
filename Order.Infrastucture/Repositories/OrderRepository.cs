using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastucture.Data;

namespace Order.Infrastucture.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;
        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var order = await _orderDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if ((order != null))
            {
                _orderDbContext.Orders.Remove(order);
            }
            return await _orderDbContext.SaveChangesAsync();
            
        }

        public Task<List<Orders>> GetAllAsync()
        {
            return _orderDbContext.Orders.ToListAsync();
        }

        public Task<Orders?> GetByCustomerIdAsync(int customerId)
        {
            return _orderDbContext.Orders.FirstOrDefaultAsync(o => o.CustomerId == customerId);
        }

        public Task<Orders?> GetByIdAsync(int id)
        {
            return _orderDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<int> InsertAsync(Orders entity)
        {
            await _orderDbContext.Orders.AddAsync(entity);
            return await _orderDbContext.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(Orders entity)
        {
            _orderDbContext.Orders.Update(entity);
            return _orderDbContext.SaveChangesAsync();
        }
    }
}
