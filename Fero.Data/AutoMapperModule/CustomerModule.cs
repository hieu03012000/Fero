using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class CustomerModule
    {
        public static void ConfigCustomerModule(this IMapperConfigurationExpression mc)
        {
            //mc.CreateMap<Customer, CreateCustomerAccountViewModel>();
            //mc.CreateMap<CreateCustomerAccountViewModel, Customer>()
            //    .ForMember(des => des.Status, opt => opt.MapFrom(src => true));
        }
    }
}
