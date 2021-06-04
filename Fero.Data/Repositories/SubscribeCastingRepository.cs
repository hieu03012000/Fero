using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ISubscribeCastingRepository :IBaseRepository<SubscribeCasting>
    {
    }
    public partial class SubscribeCastingRepository :BaseRepository<SubscribeCasting>, ISubscribeCastingRepository
    {
         public SubscribeCastingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

