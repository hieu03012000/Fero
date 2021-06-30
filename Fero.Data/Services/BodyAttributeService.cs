using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IBodyAttributeService:IBaseService<BodyAttribute>
    {
        Task<IQueryable<GetMeasureViewModel>> GetMeasure(string modelId, string type);
        Task<ICollection<UpdateMeasureViewModel>> UpdateMeasures(ICollection<UpdateMeasureViewModel> viewModels);
    }
    public partial class BodyAttributeService:BaseService<BodyAttribute>,IBodyAttributeService
    {

        private readonly IMapper _mapper;
        private readonly IBodyPartRepository _bodyPartRepository;
        public BodyAttributeService(IBodyAttributeRepository repository, IMapper mapper,
            IBodyPartRepository bodyPartRepository):base(repository){
            _mapper = mapper;
            _bodyPartRepository = bodyPartRepository;

        }

        public async Task<ICollection<UpdateMeasureViewModel>> UpdateMeasures(ICollection<UpdateMeasureViewModel> viewModels)
        {
            var bodyAtts = Get(a => viewModels.Select(m => m.Id).Contains((int)a.Id));
            for (int i = 0; i < viewModels.Count; i++)
            {
                await UpdateAsync(_mapper.Map<BodyAttribute>(viewModels.ElementAt(i)));
            }
            return viewModels;
        }

        public async Task<IQueryable<GetMeasureViewModel>> GetMeasure (string modelId, string type) //22 23 24 25
        {
            var bodyPartId = await GetMeasureID(modelId, type);
            var measure = await FirstOrDefaultAsyn(m => bodyPartId.Contains((int) m.BodyPartId));
            if (measure == null) return null;
            var list = Get(m => bodyPartId.Contains((int)m.BodyPartId)).ProjectTo<GetMeasureViewModel>(_mapper.ConfigurationProvider);
            return list;
        }


        private async Task<int[]> GetMeasureID(string modelId, string type)
        {
            int[] listType = new int [0];
            var id = await FirstOrDefaultAsyn(m => m.BodyPart.ModelId == modelId);
            if (id == null) return null;
            if("body".Equals(type.ToLower()))
            {
                int[] types = { 24, 9, 21, 8};
                listType = types;
            }

            var listId = _bodyPartRepository.Get(m => m.ModelId == modelId && listType.Contains((int) m.BodyPartTypeId))
                .Select(m => m.Id).ToArray();

            return listId;
        }
    }
}
