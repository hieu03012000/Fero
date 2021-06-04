using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IModelRepository :IBaseRepository<Model>
    {
    }
    public partial class ModelRepository :BaseRepository<Model>, IModelRepository
    {
         public ModelRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

