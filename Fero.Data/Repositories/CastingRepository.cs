using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ICastingRepository :IBaseRepository<Casting>
    {
    }
    public partial class CastingRepository :BaseRepository<Casting>, ICastingRepository
    {
         public CastingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

