using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ITattooTypeRepository :IBaseRepository<TattooType>
    {
    }
    public partial class TattooTypeRepository :BaseRepository<TattooType>, ITattooTypeRepository
    {
         public TattooTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

