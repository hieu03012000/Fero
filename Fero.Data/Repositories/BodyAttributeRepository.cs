using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBodyAttributeRepository :IBaseRepository<BodyAttribute>
    {
    }
    public partial class BodyAttributeRepository :BaseRepository<BodyAttribute>, IBodyAttributeRepository
    {
         public BodyAttributeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

