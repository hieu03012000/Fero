using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IProductService:IBaseService<Product>
    {
    }
    public partial class ProductService:BaseService<Product>,IProductService
    {
        public ProductService(IProductRepository repository):base(repository){}
    }
}
