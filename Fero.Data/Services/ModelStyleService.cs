using AutoMapper;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface IModelStyleService:IBaseService<ModelStyle>
    {
    }
    public partial class ModelStyleService:BaseService<ModelStyle>,IModelStyleService
    {
        IMapper _mapper;
        public ModelStyleService(IModelStyleRepository repository, IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }
    }
}
