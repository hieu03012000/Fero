using AutoMapper;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Reso.Core.Custom;
using System.Net;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IApplyCastingService:IBaseService<ApplyCasting>
    {
        Task<CreateApplyCastingViewModel> ApplyCasting(CreateApplyCastingViewModel aplly);
    }
    public partial class ApplyCastingService:BaseService<ApplyCasting>,IApplyCastingService
    {
        IMapper _mapper;
        public ApplyCastingService(IApplyCastingRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<CreateApplyCastingViewModel> ApplyCasting(CreateApplyCastingViewModel aplly)
        {
            var check = await Get(a => a.ModelId == aplly.ModelId && a.CastingId == aplly.CastingId).FirstOrDefaultAsync();
            if(check != null)
                 throw new ErrorResponse((int)HttpStatusCode.NotFound, "Existed");
            await CreateAsyn(_mapper.Map<ApplyCasting>(aplly));
            return aplly;
        }
    }
}
