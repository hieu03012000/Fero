using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ITaskRepository :IBaseRepository<Task>
    {
    }
    public partial class TaskRepository :BaseRepository<Task>, ITaskRepository
    {
         public TaskRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

