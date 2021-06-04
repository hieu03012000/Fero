using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IProductRepository :IBaseRepository<Product>
    {
    }
    public partial class ProductRepository :BaseRepository<Product>, IProductRepository
    {
         public ProductRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

