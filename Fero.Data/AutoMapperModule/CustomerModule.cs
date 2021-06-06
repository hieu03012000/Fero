using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class CustomerModule
    {
        public static void ConfigCustomerModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Customer, UpdateCustomerViewModel>();
            mc.CreateMap<UpdateCustomerViewModel, Customer>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => true)); 
            
            mc.CreateMap<Customer, CustomerProfileViewModel>();
            mc.CreateMap<CustomerProfileViewModel, Customer>();
        }
    }
}
