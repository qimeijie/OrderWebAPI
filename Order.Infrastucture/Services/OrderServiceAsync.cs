using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Model;

namespace Order.Infrastucture.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IMemoryCache memoryCache;
        private readonly IOrderRepositoryAsync orderRepositoryAsync;
        private readonly IMapper mapper;

        public OrderServiceAsync(IMemoryCache memoryCache, IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper)
        {
            this.memoryCache = memoryCache;
            this.orderRepositoryAsync = orderRepositoryAsync;
            this.mapper = mapper;
        }
        public Task<int> DeleteAsync(int id)
        {
            return orderRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
        {
            var response = memoryCache.Get<IEnumerable<OrderResponseModel>>("orders");
            if(response == null)
            {
                response = mapper.Map<IEnumerable<OrderResponseModel>>(await orderRepositoryAsync.GetAllAsync());
                memoryCache.Set("orders", response, TimeSpan.FromMinutes(1));
            }
            return response;
        }

        public async Task<OrderResponseModel?> GetByCustomerIdAsync(int customerId)
        {
            var order = await orderRepositoryAsync.GetByCustomerIdAsync(customerId);
            return mapper.Map<OrderResponseModel>(order);
        }

        public async Task<OrderResponseModel?> GetByIdAsync(int id)
        {
            var order = await orderRepositoryAsync.GetByIdAsync(id);
            return mapper.Map<OrderResponseModel>(order);
        }

        public Task<int> InsertAsync(OrderRequestModel entity)
        {
            var o = mapper.Map<Orders>(entity);
            return orderRepositoryAsync.InsertAsync(o);
        }

        public Task<int> UpdateAsync(OrderRequestModel entity)
        {
            var o = mapper.Map<Orders>(entity);
            return orderRepositoryAsync.UpdateAsync(o);
        }
    }
}
