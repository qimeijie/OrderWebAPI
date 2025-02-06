using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepository : IRepository<Orders>
    {
        Task<Orders?> GetByCustomerIdAsync(int customerId);
    }
}
