using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class CastingModule
    {
        public static void ConfigCastingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Casting, GetCastingViewModel>()
                .ForMember(des => des.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));
            mc.CreateMap<GetCastingViewModel, Casting>();

            mc.CreateMap<Casting, CastingListViewModel>();
            mc.CreateMap<CastingListViewModel, Casting>();

            //mc.CreateMap<Casting, MakeOfferViewModel>();
            //mc.CreateMap<MakeOfferViewModel, Casting>();

            //mc.CreateMap<Casting, UpdateCastingViewModel>();
            //mc.CreateMap<UpdateCastingViewModel, Casting>();
        }
    }
}
