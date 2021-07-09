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
        Task<AddImageViewModel> AddImage(string modelId, int collectionId, AddImageViewModel addImageViewModel);
        Task<IQueryable<ModelImageViewModel>> GetAllModelImage(string modelId);
        Task<IQueryable<GetAllModelViewModel>> GetAllModel();
        Task<int?> ChangeStatus(string modelId, int status);
        Task<bool> UpdateAvatar(UpdateAvatarViewModel viewModel);
        Task<IQueryable<ModelScheduleViewModel>> GetModelTask(string modelId);
        Task<AfterLoginViewModel> GetModelTaskByMail(string mail);
    }
    public partial class ModelService : BaseService<Model>, IModelService
    {
        private readonly IMapper _mapper;
        private readonly IModelStyleRepository _modelStyleRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICollectionImageRepository _collectionImageRepository;
        private readonly IBodyPartRepository _bodyPartRepository;
        private readonly ITaskRepository _taskRepository;

        public ModelService(IModelRepository modelRepository, IMapper mapper,
            IModelStyleRepository modelStyleRepository,
            ICollectionImageRepository collectionImageRepository,
            IBodyPartRepository bodyPartRepository,
            ITaskRepository taskRepository,
            IImageRepository imageRepository) : base(modelRepository)
        {
            _mapper = mapper;
            _modelStyleRepository = modelStyleRepository;
            _collectionImageRepository = collectionImageRepository;
            _bodyPartRepository = bodyPartRepository;
            _taskRepository = taskRepository;
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
            string id = GetModelId();
            entity.Id = id;
            entity.ModelStyle.Add(new ModelStyle { ModelId = id, StyleId = 1 });

            var fullBody = new BodyPart { BodyPartTypeId = 24, ModelId = id };
            fullBody.BodyAttribute.Add(new BodyAttribute { BodyAttTypeId = 1, Value = 0 });
            fullBody.BodyAttribute.Add(new BodyAttribute { BodyAttTypeId = 2, Value = 0 });

            var bust = new BodyPart { BodyPartTypeId = 9, ModelId = id };
            bust.BodyAttribute.Add(new BodyAttribute { BodyAttTypeId = 5, Value = 0 });

            var waist = new BodyPart { BodyPartTypeId = 21, ModelId = id };
            waist.BodyAttribute.Add(new BodyAttribute { BodyAttTypeId = 5, Value = 0 });

            var hip = new BodyPart { BodyPartTypeId = 8, ModelId = id };
            hip.BodyAttribute.Add(new BodyAttribute { BodyAttTypeId = 5, Value = 0 });

            entity.BodyPart.Add(fullBody);
            entity.BodyPart.Add(bust);
            entity.BodyPart.Add(waist);
            entity.BodyPart.Add(hip);

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
            var model = await Get(x => x.Id == modelId)
                .ProjectTo<ModelDetailViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not found");
            return model;
        }

        public async Task<UpdateModelProfileViewModel> UpdateProfileModel(UpdateModelProfileViewModel model)
        {
            if (_mapper.Map<UpdateModelProfileViewModel>(await GetAsyn(model.Id)) == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var updatemodel = await Get(x => x.Id == model.Id).FirstOrDefaultAsync();
            updatemodel = _mapper.Map(model, updatemodel);
            await UpdateAsync(updatemodel);
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

        public async Task<AddImageViewModel> AddImage(string modelId, int collectionId, AddImageViewModel addImageViewModel)
        {
            var entity = _mapper.Map<Image>(addImageViewModel);
            entity.CollectionId = collectionId;
            await _imageRepository.CreateAsyn(entity);
            return addImageViewModel;
        }

        public async Task<IQueryable<ModelImageViewModel>> GetAllModelImage(string modelId)
        {
            if(await _imageRepository.Get(i => i.Collection.BodyPart.Model.Id == modelId).FirstOrDefaultAsync() == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var image = _imageRepository.Get(i => i.Collection.BodyPart.Model.Id == modelId).OrderByDescending(m => m.UploadDate)
                .ProjectTo<ModelImageViewModel>(_mapper.ConfigurationProvider);
            return image;
        }

        public async Task<int?> ChangeStatus(string modelId, int status)
        {
            var model = await Get(i => i.Id == modelId).FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            model.Status = status;
            await UpdateAsync(model);
            return model.Status;
        }

        public async Task<bool> UpdateAvatar(UpdateAvatarViewModel viewModel)
        {
            var model = await Get(i => i.Id == viewModel.Id).FirstOrDefaultAsync();
            if (model == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            model.Avatar = viewModel.Avatar;
            await UpdateAsync(model);
            return true;
        }

        public async Task<IQueryable<ModelScheduleViewModel>> GetModelTask(string modelId)
        {
            var model = await _taskRepository.Get(i => i.ModelId == modelId).FirstOrDefaultAsync();
            if(model == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var taskList = _taskRepository.Get(i => i.ModelId == modelId)
                .ProjectTo<ModelScheduleViewModel>(_mapper.ConfigurationProvider);
            return taskList;
        }
        
        public async Task<AfterLoginViewModel> GetModelTaskByMail(string mail)
        {
            var model = await FirstOrDefaultAsyn(m => m.Username == mail && m.Status != 2);
            if (model == null) return null;
            return _mapper.Map<AfterLoginViewModel>(model);
        }
    }
}
