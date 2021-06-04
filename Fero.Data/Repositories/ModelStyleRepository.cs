using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IModelStyleRepository :IBaseRepository<ModelStyle>
    {
    }
    public partial class ModelStyleRepository :BaseRepository<ModelStyle>, IModelStyleRepository
    {
         public ModelStyleRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

