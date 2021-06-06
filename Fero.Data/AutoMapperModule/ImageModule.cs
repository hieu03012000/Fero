using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class ImageModule
    {
        public static void ConfigImageModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Image, CreateAccountImageViewModel>();
            mc.CreateMap<CreateAccountImageViewModel, Image>()
                .ForMember(dest => dest.UploadDate, opts => opts.MapFrom(src => DateTime.Now));

            mc.CreateMap<Image, int>();
            mc.CreateMap<int, Image>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src));
      
            mc.CreateMap<Image, ModelImageViewModel>();
            mc.CreateMap<ModelImageViewModel, Image>();
            
            mc.CreateMap<Image, AddImageViewModel>();
            mc.CreateMap<AddImageViewModel, Image>()
                .ForMember(dest => dest.UploadDate, opts => opts.MapFrom(src => DateTime.Now));

            mc.CreateMap<Image, ModelDetailImageViewModel>();
            mc.CreateMap<ModelDetailImageViewModel, Image>();
        }
    }
}
