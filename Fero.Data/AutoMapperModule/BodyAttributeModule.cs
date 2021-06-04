using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class BodyAttributeModule
    {
        public static void ConfigBodyAttributeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<BodyAttribute, CreateAccountBodyAttributeViewModel>();
            mc.CreateMap<CreateAccountBodyAttributeViewModel, BodyAttribute>();

            mc.CreateMap<BodyAttribute, ModelDetailBodyAttributeViewModel>()
            .ForMember(des => des.BodyAttName, opt => opt.MapFrom(src => src.BodyAttType.Name))
            .ForMember(des => des.Measure, opt => opt.MapFrom(src => src.BodyAttType.Measure));
            mc.CreateMap<ModelDetailBodyAttributeViewModel, BodyAttribute>();
        }
    }
}
