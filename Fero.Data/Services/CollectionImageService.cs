using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ICollectionImageService:IBaseService<CollectionImage>
    {
    }
    public partial class CollectionImageService:BaseService<CollectionImage>,ICollectionImageService
    {
        public CollectionImageService(ICollectionImageRepository repository):base(repository){}
    }
}
