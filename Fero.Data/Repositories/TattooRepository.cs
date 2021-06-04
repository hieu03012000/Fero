using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ITattooRepository :IBaseRepository<Tattoo>
    {
    }
    public partial class TattooRepository :BaseRepository<Tattoo>, ITattooRepository
    {
         public TattooRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

