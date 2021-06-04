using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IApplyCastingRepository :IBaseRepository<ApplyCasting>
    {
    }
    public partial class ApplyCastingRepository :BaseRepository<ApplyCasting>, IApplyCastingRepository
    {
         public ApplyCastingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

