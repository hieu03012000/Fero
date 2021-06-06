using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class TaskModule
    {
        public static void ConfigTaskModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Task, ModelScheduleViewModel>();
            mc.CreateMap<ModelScheduleViewModel, Task>();
        }
    }
}
