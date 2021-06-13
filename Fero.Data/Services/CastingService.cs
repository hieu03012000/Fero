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

namespace Fero.Data.Services
{
    public partial interface ICastingService : IBaseService<Casting>
    {
        Task<GetCastingViewModel> ShowDetailCasting(string customerId, int c);
        Task<IQueryable<CastingListViewModel>> GetCastingList();
    }
    public partial class CastingService : BaseService<Casting>, ICastingService
    {
        private readonly IMapper _mapper;
        private readonly ICastingRepository _castingRepository;
        private readonly ITaskRepository _taskRepository;

        public CastingService(ICastingRepository castingRepository, ITaskRepository taskRepository, IMapper mapper) : base(castingRepository)
        {
            _mapper = mapper;
            _castingRepository = castingRepository;
            _taskRepository = taskRepository;
        }

        public async Task<GetCastingViewModel> ShowDetailCasting(string customerId, int castingId)
        {
            var customerCasting = await Get(x => x.CustomerId == customerId && x.Id == castingId)
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (customerCasting == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            return customerCasting;
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
            await _castingRepository.CreateAsyn(casting);
        }

        //Tao casting vs form casting va customerId
        public async void CreateCasting(string customerId, Casting casting)
        {
            casting.CustomerId = customerId;
            await _castingRepository.CreateAsyn(casting);
        }

        public async Task<IQueryable<CastingListViewModel>> GetCastingList()
        {
            if (await FirstOrDefaultAsyn() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not have model");
            var list = Get().ProjectTo<CastingListViewModel>(_mapper.ConfigurationProvider);
            return list;
        }
    }
}
