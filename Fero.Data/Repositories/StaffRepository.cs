using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IStaffRepository :IBaseRepository<Staff>
    {
    }
    public partial class StaffRepository :BaseRepository<Staff>, IStaffRepository
    {
         public StaffRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

