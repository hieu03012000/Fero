using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class TaskModule
    {
        public static void ConfigTaskModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Task, ModelScheduleViewModel>()
                .ForMember(des => des.CastingName, opt => opt.MapFrom(src => src.Casting.Name));
            mc.CreateMap<ModelScheduleViewModel, Task>();

            mc.CreateMap<Task, CreateFreeTimeViewModel>();
            mc.CreateMap<CreateFreeTimeViewModel, Task>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => 0));
            
            mc.CreateMap<Task, CreateTaskViewModel>();
            mc.CreateMap<CreateTaskViewModel, Task>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => 1));
        }
    }
}
