using AutoMapper;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Model;

namespace Order.Infrastucture
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Orders, OrderResponseModel>().ReverseMap();
            CreateMap<Orders, OrderRequestModel>().ReverseMap();
        }
    }
}
