using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class SubscribeCastingModule
    {
        public static void ConfigSubscribeCastingModule(this IMapperConfigurationExpression mc)
        {
            //mc.CreateMap<SubscribeCasting, SubscribeCastingViewModel>();
            //mc.CreateMap<SubscribeCastingViewModel, SubscribeCasting>();
        }
    }
}
