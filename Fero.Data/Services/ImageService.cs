using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IImageService:IBaseService<Image>
    {
    }
    public partial class ImageService:BaseService<Image>,IImageService
    {
        public ImageService(IImageRepository repository):base(repository){}
    }
}
