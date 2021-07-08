using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using AutoMapper;
using System.Threading.Tasks;
using Reso.Core.Custom;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Fero.Data.ViewModels;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Collections.Generic;

namespace Fero.Data.Services
{
    public partial interface ICastingService : IBaseService<Casting>
    {
        Task<GetCastingViewModel> ShowDetailCasting(int c);
        Task<IQueryable<GetCastingViewModel>> GetCastingList();
        Task<IQueryable<GetCastingViewModel>> SearchCasting(SearchValue value);
        Task<IQueryable<GetCastingViewModel>> GetCastingModelApply(string modelId);
        Task<IQueryable<GetCastingViewModel>> GetCastingListByIds(List<int> castingIds);
    }
    public partial class CastingService : BaseService<Casting>, ICastingService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IApplyCastingRepository _applyCastingRepository;
        private readonly IThreadService _threadService;

        public CastingService(ICastingRepository castingRepository,
            ITaskRepository taskRepository, IApplyCastingRepository applyCastingRepository,
            IThreadService threadService,
            IMapper mapper) : base(castingRepository)
        {
            _mapper = mapper;
            _threadService = threadService;
            _taskRepository = taskRepository;
            _applyCastingRepository = applyCastingRepository;
        }

        public async Task<GetCastingViewModel> ShowDetailCasting(int castingId)
        {
            var customerCasting = await Get(x => x.Id == castingId)
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (customerCasting == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            return customerCasting;
        }

        private async Task<decimal?> GetMaxSalary()
        {
            return await Get().OrderByDescending(c => c.Salary).Select(c => c.Salary).FirstOrDefaultAsync();
        }     

        public async Task<IQueryable<GetCastingViewModel>> SearchCasting(SearchValue value)
        {
            var check = await FirstOrDefaultAsyn(); 
            if(check == null) throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not have casting");
            if (value.name == null) value.name = "";
            if (value.min == null) value.min = 0;
            if (value.max == null) value.max = await GetMaxSalary();
            var result = Get(c => c.Name.Contains(value.name) && c.Salary > value.min && c.Salary < value.max &&
            (c.Status == 1 || c.Status == 2 || c.Status == 3)).OrderByDescending(c => c.Salary)
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider);
            if (result == null) throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not have casting");
            return result;
        }

        //Tao taskDB vs form task
        public async void CreateTask(Fero.Data.Models.Task task)
        {
            await _taskRepository.CreateAsyn(task);
        }

        //Tao taskDB vs form task + castingId
        public async void CreateTask(int castingId, Fero.Data.Models.Task task)
        {
            task.CastingId = castingId;
            await _taskRepository.CreateAsyn(task);
        }

        //Tao taskDB vs form task + form casting
        public async void CreateTask(Casting casting, Fero.Data.Models.Task task)
        {
            task.Casting = casting;
            await _taskRepository.CreateAsyn(task);
        }

        //Tao casting vs form casting
        public async void CreateCasting(Casting casting)
        {
            await CreateAsyn(casting);
        }

        //Tao casting vs form casting va customerId
        public async void CreateCasting(string customerId, Casting casting)
        {
            casting.CustomerId = customerId;
            await CreateAsyn(casting);
        }

        public async Task<IQueryable<GetCastingViewModel>> GetCastingList()
        {
            if (await Get(x => x.Status == 1 || x.Status == 2 || x.Status == 3).FirstOrDefaultAsync() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not have catsing");
            var list = Get(x => x.Status == 1 || x.Status == 2 || x.Status == 3)
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider);
            return list;
        }

        public async Task<IQueryable<GetCastingViewModel>> GetCastingListByIds(List<int> castingIds)
        {
            if (await Get(x => x.Status == 1 || x.Status == 2 || x.Status == 3).FirstOrDefaultAsync() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not have catsing");
            var list = Get(x => (x.Status == 1 || x.Status == 2 || x.Status == 3) && castingIds.Contains(x.Id))
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider);
            return list;
        }

        public async Task<IQueryable<GetCastingViewModel>> GetCastingModelApply(string modelId)
        {
            if((await _applyCastingRepository.FirstOrDefaultAsyn(a => a.ModelId == modelId)) == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not have catsing");
            var casitingIds = _applyCastingRepository.Get(a => a.ModelId == modelId).Select(a => a.CastingId);
            var castingList = Get(c => casitingIds.Contains(c.Id)).ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider);
            return castingList;
        }
    }
}
