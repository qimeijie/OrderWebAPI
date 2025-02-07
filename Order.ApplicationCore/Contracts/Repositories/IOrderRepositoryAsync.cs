using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Orders>
    {
        Task<Orders?> GetByCustomerIdAsync(int customerId);
    }
}
