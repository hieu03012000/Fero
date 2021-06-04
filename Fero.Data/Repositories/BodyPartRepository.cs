using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBodyPartRepository :IBaseRepository<BodyPart>
    {
    }
    public partial class BodyPartRepository :BaseRepository<BodyPart>, IBodyPartRepository
    {
         public BodyPartRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

