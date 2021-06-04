using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IBodyAttributeTypeRepository :IBaseRepository<BodyAttributeType>
    {
    }
    public partial class BodyAttributeTypeRepository :BaseRepository<BodyAttributeType>, IBodyAttributeTypeRepository
    {
         public BodyAttributeTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

