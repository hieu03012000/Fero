using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBrandCategoryRepository :IBaseRepository<BrandCategory>
    {
    }
    public partial class BrandCategoryRepository :BaseRepository<BrandCategory>, IBrandCategoryRepository
    {
         public BrandCategoryRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

