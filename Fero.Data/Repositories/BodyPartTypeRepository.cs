using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBodyPartTypeRepository :IBaseRepository<BodyPartType>
    {
    }
    public partial class BodyPartTypeRepository :BaseRepository<BodyPartType>, IBodyPartTypeRepository
    {
         public BodyPartTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

