using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
namespace Fero.Data.Commons
{
    public static class AutoMapperConfig
    {

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                //mc.ConfigModelModule();
                //mc.ConfigBodyPartModule();
                //mc.ConfigModelStyleModule();
                //mc.ConfigProductModule();
                //mc.ConfigBodyAttributeModule();
                //mc.ConfigCollectionImageModule();
                //mc.ConfigImageModule();
                //mc.ConfigCastingModule();
                //mc.ConfigApplyCastingModule();
                //mc.ConfigSubscribeCastingModule();
                //mc.ConfigModelCastingModule();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
