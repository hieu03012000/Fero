using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ICashLevelRepository :IBaseRepository<CashLevel>
    {
    }
    public partial class CashLevelRepository :BaseRepository<CashLevel>, ICashLevelRepository
    {
         public CashLevelRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

