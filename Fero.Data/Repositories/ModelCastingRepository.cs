using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IModelCastingRepository :IBaseRepository<ModelCasting>
    {
    }
    public partial class ModelCastingRepository :BaseRepository<ModelCasting>, IModelCastingRepository
    {
         public ModelCastingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

