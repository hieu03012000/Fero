using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class CollectionImageModule
    {
        public static void ConfigCollectionImageModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<CollectionImage, CreateAccountCollectionImageViewModel>();
            mc.CreateMap<CreateAccountCollectionImageViewModel, CollectionImage>();

            mc.CreateMap<CollectionImage, ModelDetailCollectionImageViewModel>();
            mc.CreateMap<ModelDetailCollectionImageViewModel, CollectionImage>();

            mc.CreateMap<CollectionImage, ImageCollectionViewModel>();
            mc.CreateMap<ImageCollectionViewModel, CollectionImage>();
        }
    }
}
