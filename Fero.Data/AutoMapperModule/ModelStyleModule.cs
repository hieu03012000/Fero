using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class ModelStyleModule
    {
        public static void ConfigModelStyleModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ModelStyle, CreateAccountModelStyleViewModel>();
            mc.CreateMap<CreateAccountModelStyleViewModel, ModelStyle>();

            mc.CreateMap<ModelStyle, ModelDetailModelStyleViewModel>()
                 .ForMember(des => des.StyleName, opt => opt.MapFrom(src => src.Style.Name));
            mc.CreateMap<ModelDetailModelStyleViewModel, ModelStyle>();

            mc.CreateMap<ModelStyle, UpdateModelStyleViewModel>()
                 .ForMember(des => des.Id, opt => opt.MapFrom(src => src.ModelId))
                 .ForMember(des => des.ModelStyle, opt => opt.MapFrom(src => src.StyleId));
            mc.CreateMap<UpdateModelStyleViewModel, ModelStyle>();
        }
    }
}
