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
    }
    public partial class CollectionImageService:BaseService<CollectionImage>,ICollectionImageService
    {
        IMapper _mapper;
        public CollectionImageService(ICollectionImageRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<IQueryable<ImageCollectionViewModel>> GetCollection(string modelId)
        {
            if (await Get(c => c.BodyPart.ModelId == modelId).FirstOrDefaultAsync() == null)
                return null;
            var collectionList = Get(c => c.BodyPart.ModelId == modelId).ProjectTo<ImageCollectionViewModel>(_mapper.ConfigurationProvider);
            return collectionList;
        }
    }
}
