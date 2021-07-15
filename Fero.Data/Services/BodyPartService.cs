using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IBodyPartService:IBaseService<BodyPart>
    {
        Task<IQueryable<BodyPartViewModel>> GetModelBodyPart(string modelId);
    }
    public partial class BodyPartService:BaseService<BodyPart>,IBodyPartService
    {
        IMapper _mapper;
        public BodyPartService(IBodyPartRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<IQueryable<BodyPartViewModel>> GetModelBodyPart(string modelId)
        {
            if (await FirstOrDefaultAsyn(b => b.ModelId == modelId) == null)
                return null;
            var list = Get(b => b.ModelId == modelId).ProjectTo<BodyPartViewModel>(_mapper.ConfigurationProvider);
            return list;
        }
    }
}
