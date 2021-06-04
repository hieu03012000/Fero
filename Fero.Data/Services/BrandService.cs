using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBrandService:IBaseService<Brand>
    {
    }
    public partial class BrandService:BaseService<Brand>,IBrandService
    {
        public BrandService(IBrandRepository repository):base(repository){}
    }
}
