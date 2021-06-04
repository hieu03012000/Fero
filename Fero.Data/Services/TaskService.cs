using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ITaskService:IBaseService<Task>
    {
    }
    public partial class TaskService:BaseService<Task>,ITaskService
    {
        public TaskService(ITaskRepository repository):base(repository){}
    }
}
