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
using System.Collections.Generic;

namespace Fero.Data.Services
{
    public partial interface IModelService:IBaseService<Model>
    {
        Task<CreateModelAccountViewModel> CreateModelAccount(CreateModelAccountViewModel model);
        Task<ModelDetailViewModel> GetModelById(string modelId);
        Task<UpdateModelProfileViewModel> UpdateProfileModel(UpdateModelProfileViewModel model);
        Task<UpdateModelStyleViewModel> UpdateModelStyle(string id, UpdateModelStyleViewModel model);
        Task<DeleteImageViewModel> DeleteImage(string modelId, DeleteImageViewModel deleteImageViewModels);
        Task<IQueryable<ModelImageViewModel>> GetAllModelImage(string modelId);
        Task<IQueryable<GetAllModelViewModel>> GetAllModel();
        Task<bool> ChangeStatus(string modelId);
    }
    public partial class ModelService : BaseService<Model>, IModelService
    {
        private readonly IMapper _mapper;
        private readonly IModelStyleRepository _modelStyleRepository;
        private readonly IImageRepository _imageRepository;

        public ModelService(IModelRepository modelRepository, IMapper mapper,
            IModelStyleRepository modelStyleRepository,
            IImageRepository imageRepository) : base(modelRepository)
        {
            _mapper = mapper;
            _modelStyleRepository = modelStyleRepository;
            _imageRepository = imageRepository;
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

        public async Task<IQueryable<GetAllModelViewModel>> GetAllModel()
        {
            if (await FirstOrDefaultAsyn() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not have model");
            var list = Get().ProjectTo<GetAllModelViewModel>(_mapper.ConfigurationProvider);
            return list;
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
            await UpdateAsync(entity);
            return model;
        }

        public async Task<UpdateModelStyleViewModel> UpdateModelStyle(string id, UpdateModelStyleViewModel model)
        {
            if(id != model.Id)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not match id");
            var list = _modelStyleRepository.Get(ms => ms.ModelId == model.Id);
            if(list.Any())
                await _modelStyleRepository.RemoveRange(list);
            var updateModel = Get(x => x.Id == id).FirstOrDefault();
            updateModel.ModelStyle = _mapper.Map<ICollection<ModelStyle>>(model.ModelStyle);
            await UpdateAsync(updateModel);
            return model;
        }

        public async Task<DeleteImageViewModel> DeleteImage(string modelId, DeleteImageViewModel deleteImageViewModels)
        {
            var image = _imageRepository.Get(i => deleteImageViewModels.Id.Contains(i.Id));
            await _imageRepository.RemoveRange(image);
            return deleteImageViewModels;
        }

        public async Task<DeleteImageViewModel> AddImage(string modelId, DeleteImageViewModel deleteImageViewModels)
        {
            var image = _imageRepository.Get(i => deleteImageViewModels.Id.Contains(i.Id));
            await _imageRepository.RemoveRange(image);
            return deleteImageViewModels;
        }

        public async Task<IQueryable<ModelImageViewModel>> GetAllModelImage(string modelId)
        {
            if(await _imageRepository.Get(i => i.Collection.BodyPart.Model.Id == modelId).FirstOrDefaultAsync() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var image = _imageRepository.Get(i => i.Collection.BodyPart.Model.Id == modelId)
                .ProjectTo<ModelImageViewModel>(_mapper.ConfigurationProvider);
            return image;
        }

        public async Task<bool> ChangeStatus(string modelId)
        {
            var model = await Get(i => i.Id == modelId).FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            model.Status = !model.Status;
            await UpdateAsync(model);
            return model.Status;
        }

        //public async Task
    }
}
