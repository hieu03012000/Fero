using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IImageService:IBaseService<Image>
    {
        Task<IQueryable<ModelImageViewModel>> GetImage(int collectionId);
    }
    public partial class ImageService:BaseService<Image>,IImageService
    {
        IMapper _mapper;
        public ImageService(IImageRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<IQueryable<ModelImageViewModel>> GetImage(int collectionId)
        {
            if (await Get(c => c.CollectionId == collectionId).FirstOrDefaultAsync() == null)
                return null;
            var collectionList = Get(c => c.CollectionId == collectionId).OrderByDescending(m => m.UploadDate)
                .ProjectTo<ModelImageViewModel>(_mapper.ConfigurationProvider);
            return collectionList;
        }

        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        //public int CastImage(byte[] byteArr)
        //{
        //    var stream = File.Open(@"C:\Users\you\file.png", FileMode.Open);

        //    var task = new FirebaseStorage("your-bucket.appspot.com")
        //        .Child("data")
        //        .Child("random")
        //        .Child("file.png")
        //        .PutAsync(stream);

        //    // Track progress of the upload
        //    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        //    var downloadUrl = await task;

        //    return 1;
        //}

    }
}
