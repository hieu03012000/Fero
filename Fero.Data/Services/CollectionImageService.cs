using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface ICollectionImageService:IBaseService<CollectionImage>
    {
        Task<IQueryable<ImageCollectionViewModel>> GetCollection(string modelId);
        Task<AddGifViewModel> AddGif(string modelId, AddGifViewModel gif);
        Task<CreateImageCollectionViewModel> CreateCollection(CreateImageCollectionViewModel model, string modelId);
        Task<int?> DeleteCollection(int collectionId);
    }
    public partial class CollectionImageService:BaseService<CollectionImage>,ICollectionImageService
    {
        IMapper _mapper;
        IBodyPartRepository _bodyPartRepository;
        public CollectionImageService(ICollectionImageRepository repository, 
            IBodyPartRepository bodyPartRepository,
            IMapper mapper):base(repository)
        {
            _bodyPartRepository = bodyPartRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ImageCollectionViewModel>> GetCollection(string modelId)
        {
            if (await Get(c => c.BodyPart.ModelId == modelId && c.Status == true).FirstOrDefaultAsync() == null)
                return null;
            var collectionList = Get(c => c.BodyPart.ModelId == modelId && c.Status == true).ProjectTo<ImageCollectionViewModel>(_mapper.ConfigurationProvider);
            return collectionList;
        }

        public async Task<CreateImageCollectionViewModel> CreateCollection(CreateImageCollectionViewModel model, string modelId)
        {
            var body = await _bodyPartRepository.Get().FirstOrDefaultAsync(b => b.ModelId == modelId);
            if (body == null)
            {
                await _bodyPartRepository.CreateAsyn(new BodyPart { BodyPartTypeId = 24, ModelId = modelId });
                body = await _bodyPartRepository.Get().FirstOrDefaultAsync(b => b.ModelId == modelId);
            }
            var collection = _mapper.Map<CollectionImage>(model);
            collection.BodyPartId = body.Id;
            await CreateAsyn(collection);
            return model;
        }

        public async Task<int?> DeleteCollection(int collectionId)
        {
            var collectionImage = await Get().FirstOrDefaultAsync(b => b.Id == collectionId);
            if (collectionImage == null)
            {
                return null;
            }
            collectionImage.Status = false;
            await UpdateAsync(collectionImage);
            return collectionId;
        }

        public async Task<AddGifViewModel> AddGif(string modelId, AddGifViewModel gif)
        {
            var collection = await Get(c => c.Id == gif.CollectionId).FirstOrDefaultAsync();
            if (collection == null)
                return null;
            collection.Gif = gif.Gif;
            await UpdateAsync(collection);
            return gif;
        }
    }
}
