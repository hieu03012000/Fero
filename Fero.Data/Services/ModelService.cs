using AutoMapper;
using Fero.Data.Models;
using Fero.Data.ViewModels;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using Reso.Core.Custom;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Fero.Data.Services
{
    public partial interface IModelService:IBaseService<Model>
    {
        Task<CreateModelAccountViewModel> CreateModelAccount(CreateModelAccountViewModel model);
        Task<ModelDetailViewModel> GetModelById(string modelId);
        Task<UpdateModelProfileViewModel> UpdateProfileModel(UpdateModelProfileViewModel model);
    }
    public partial class ModelService : BaseService<Model>, IModelService
    {
        private readonly IMapper _mapper;

        public ModelService(IModelRepository modelRepository, IMapper mapper): base(modelRepository)
        {
            _mapper = mapper;
        }

        private string GetModelId()
        {
            var modelId = Get().OrderByDescending(m => m.Id).FirstOrDefault().Id;
            int num = int.Parse(modelId.Substring(2));
            return "MD" + string.Format("{0 :D4}", ++num);
        }

        public async Task<CreateModelAccountViewModel> CreateModelAccount(CreateModelAccountViewModel model)
        {
            if (await FirstOrDefaultAsyn(m => m.Username == model.Username) != null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Duplicate");
            var entity = _mapper.Map<Model>(model);
            entity.Id = GetModelId();
            await CreateAsyn(entity);
            return model;
        }

        public async Task<ModelDetailViewModel> GetModelById(string modelId)
        {
            var model = await Get(x => x.Id == modelId && x.Status)
                .ProjectTo<ModelDetailViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not found");
            return model;
        }

        public async Task<UpdateModelProfileViewModel> UpdateProfileModel(UpdateModelProfileViewModel model)
        {
            if (_mapper.Map<UpdateModelProfileViewModel>(await GetAsyn(model.Id)) == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var entity = _mapper.Map<Model>(model);
            Update(entity);
            return model;
        }
    }
}
