using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.AutoMapperModule
{
    public static class StaffModule
    {
        public static void ConfigStaffModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Staff, StaffLoginViewModel>();
            mc.CreateMap<StaffLoginViewModel, Staff>();

        }
    }
}
