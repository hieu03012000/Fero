using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IStyleRepository :IBaseRepository<Style>
    {
    }
    public partial class StyleRepository :BaseRepository<Style>, IStyleRepository
    {
         public StyleRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

