using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IImageRepository :IBaseRepository<Image>
    {
    }
    public partial class ImageRepository :BaseRepository<Image>, IImageRepository
    {
         public ImageRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

