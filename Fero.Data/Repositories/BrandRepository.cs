using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBrandRepository :IBaseRepository<Brand>
    {
    }
    public partial class BrandRepository :BaseRepository<Brand>, IBrandRepository
    {
         public BrandRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

