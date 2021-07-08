using Fero.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Fero.Data.Services;
using Fero.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fero.Data.Commons
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDI(this IServiceCollection services)
        {
            services.AddScoped<DbContext, FeroContext>();
        
            services.AddScoped<IApplyCastingService, ApplyCastingService>();
            services.AddScoped<IApplyCastingRepository, ApplyCastingRepository>();
        
            services.AddScoped<IBodyAttributeService, BodyAttributeService>();
            services.AddScoped<IBodyAttributeRepository, BodyAttributeRepository>();
        
            services.AddScoped<IBodyAttributeTypeService, BodyAttributeTypeService>();
            services.AddScoped<IBodyAttributeTypeRepository, BodyAttributeTypeRepository>();
        
            services.AddScoped<IBodyPartService, BodyPartService>();
            services.AddScoped<IBodyPartRepository, BodyPartRepository>();
        
            services.AddScoped<IBodyPartTypeService, BodyPartTypeService>();
            services.AddScoped<IBodyPartTypeRepository, BodyPartTypeRepository>();
        
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();
        
            services.AddScoped<IBrandCategoryService, BrandCategoryService>();
            services.AddScoped<IBrandCategoryRepository, BrandCategoryRepository>();
        
            services.AddScoped<ICashLevelService, CashLevelService>();
            services.AddScoped<ICashLevelRepository, CashLevelRepository>();
        
            services.AddScoped<ICastingService, CastingService>();
            services.AddScoped<ICastingRepository, CastingRepository>();
        
            services.AddScoped<ICollectionImageService, CollectionImageService>();
            services.AddScoped<ICollectionImageRepository, CollectionImageRepository>();
        
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();
        
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();
        
            services.AddScoped<IModelCastingService, ModelCastingService>();
            services.AddScoped<IModelCastingRepository, ModelCastingRepository>();
        
            services.AddScoped<IModelStyleService, ModelStyleService>();
            services.AddScoped<IModelStyleRepository, ModelStyleRepository>();
        
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
        
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        
            services.AddScoped<IPaymentAccountService, PaymentAccountService>();
            services.AddScoped<IPaymentAccountRepository, PaymentAccountRepository>();
        
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
        
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffRepository, StaffRepository>();
        
            services.AddScoped<IStyleService, StyleService>();
            services.AddScoped<IStyleRepository, StyleRepository>();
        
            services.AddScoped<ISubscribeCastingService, SubscribeCastingService>();
            services.AddScoped<ISubscribeCastingRepository, SubscribeCastingRepository>();
        
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        
            services.AddScoped<ITattooService, TattooService>();
            services.AddScoped<ITattooRepository, TattooRepository>();
        
            services.AddScoped<ITattooTypeService, TattooTypeService>();
            services.AddScoped<ITattooTypeRepository, TattooTypeRepository>();

            services.AddScoped<IThreadService, ThreadService>();
            //services.AddScoped<ITattooTypeRepository, TattooTypeRepository>();
        }
    }
}
