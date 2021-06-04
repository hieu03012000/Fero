using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class ProductModule
    {
        public static void ConfigProductModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Product, CreateAccountProductViewModel>();
            mc.CreateMap<CreateAccountProductViewModel, Product>();

            mc.CreateMap<Product, ModelDetailProductViewModel>();
            mc.CreateMap<ModelDetailProductViewModel, Product>();
        }
    }
}
