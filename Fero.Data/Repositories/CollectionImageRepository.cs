using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ICollectionImageRepository :IBaseRepository<CollectionImage>
    {
    }
    public partial class CollectionImageRepository :BaseRepository<CollectionImage>, ICollectionImageRepository
    {
         public CollectionImageRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

