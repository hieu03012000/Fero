using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class BodyPartModule
    {
        public static void ConfigBodyPartModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<BodyPart, CreateAccountBodyPartViewModel>();
            mc.CreateMap<CreateAccountBodyPartViewModel, BodyPart>();

            mc.CreateMap<BodyPart, ModelDetailBodyPartViewModel>()
            .ForMember(des => des.BodyPartTypeName, opt => opt.MapFrom(src => src.BodyPartType.Name));
            mc.CreateMap<ModelDetailBodyPartViewModel, BodyPart>();
        }
    }
}
