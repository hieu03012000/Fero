using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;

namespace Fero.Data.AutoMapperModule
{
    public static class ModelModule
    {
        public static void ConfigModelModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Model, CreateModelAccountViewModel>();
            mc.CreateMap<CreateModelAccountViewModel, Model>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => false));

            mc.CreateMap<Model, ModelDetailViewModel>();
            mc.CreateMap<ModelDetailViewModel, Model>();
            
            mc.CreateMap<Model, UpdateAvatarViewModel>();
            mc.CreateMap<UpdateAvatarViewModel, Model>();
            
            mc.CreateMap<Model, GetAllModelViewModel>();
            mc.CreateMap<GetAllModelViewModel, Model>();
            
            mc.CreateMap<Model, UpdateModelProfileViewModel>();
            mc.CreateMap<UpdateModelProfileViewModel, Model>();
                  
            mc.CreateMap<Model, UpdateModelStyleViewModel>();
            mc.CreateMap<UpdateModelStyleViewModel, Model>();

            //mc.CreateMap<Model, ApplicantListViewModel>();
            //mc.CreateMap<ApplicantListViewModel, Model>();
        }
    }
}
