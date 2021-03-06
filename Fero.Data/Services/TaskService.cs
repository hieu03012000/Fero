using AutoMapper;
using models = Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using System.Threading.Tasks;
using System;
using Reso.Core.Custom;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Fero.Data.Services
{
    public partial interface ITaskService:IBaseService<models.Task>
    {
        Task<bool> CheckValidTaskTime(string modelId, DateTime begin, DateTime end);
        Task<CreateFreeTimeViewModel> CreateFreeTime(CreateFreeTimeViewModel model);
        Task<CreateTaskViewModel> CreateTask(CreateTaskViewModel model);
        Task<IQueryable<ModelScheduleViewModel>> IncomingTaskByCasting(int castingId, string modelId);
    }
    public partial class TaskService:BaseService<models.Task>,ITaskService
    {
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<bool> CheckValidTaskTime(string modelId, DateTime begin, DateTime end)
        {
            if(begin > end) throw new ErrorResponse((int)HttpStatusCode.BadRequest, "begin > end");
            var check = await Get(t => t.ModelId == modelId && ((t.StartAt < begin && begin < t.EndAt) 
            || (t.StartAt < end && end < t.EndAt || (begin < t.StartAt && end > t.EndAt)))).FirstOrDefaultAsync();
            if (check != null) return false;
            return true;
        }

        public async Task<CreateFreeTimeViewModel> CreateFreeTime(CreateFreeTimeViewModel model)
        {
            if (await CheckValidTaskTime(model.ModelId, model.StartAt, model.EndAt))
            {
                await CreateAsyn(_mapper.Map<models.Task>(model));
                return model;
            }
            throw new ErrorResponse((int)HttpStatusCode.BadRequest, "cannot create");
            
        }

        public async Task<CreateTaskViewModel> CreateTask(CreateTaskViewModel model)
        {
            if (await CheckValidTaskTime(model.ModelId, model.StartAt, model.EndAt))
            {
                await CreateAsyn(_mapper.Map<models.Task>(model));
                return model;
            }
            else throw new ErrorResponse((int)HttpStatusCode.BadRequest, "cannot create");
            
        }

        public async Task<IQueryable<ModelScheduleViewModel>> IncomingTaskByCasting(int castingId, string modelId)
        {
            var model = await Get(i => i.CastingId == castingId && i.ModelId == modelId && i.StartAt > DateTime.Now)
                .FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var taskList = Get(i => i.CastingId == castingId && i.ModelId == modelId && i.StartAt > DateTime.Now)
                .OrderByDescending(i => i.StartAt)
                .ProjectTo<ModelScheduleViewModel>(_mapper.ConfigurationProvider);
            return taskList;
        }
    }
}
