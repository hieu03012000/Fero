using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class ApplyCastingModule
    {
        public static void ConfigApplyCastingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<CreateApplyCastingViewModel, ApplyCasting>();
            mc.CreateMap<ApplyCasting, CreateApplyCastingViewModel>();
        }
    }
}
