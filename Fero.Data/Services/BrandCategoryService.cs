using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBrandCategoryService:IBaseService<BrandCategory>
    {
    }
    public partial class BrandCategoryService:BaseService<BrandCategory>,IBrandCategoryService
    {
        public BrandCategoryService(IBrandCategoryRepository repository):base(repository){}
    }
}
