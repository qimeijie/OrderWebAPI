using Order.ApplicationCore.Model;

namespace Order.ApplicationCore.Contracts.Services
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderResponseModel>> GetAllAsync();
        Task<OrderResponseModel?> GetByIdAsync(int id);
        Task<int> InsertAsync(OrderRequestModel entity);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(OrderRequestModel entity);
        Task<OrderResponseModel?> GetByCustomerIdAsync(int customerId);
    }
}
