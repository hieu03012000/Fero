using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IModelStyleService:IBaseService<ModelStyle>
    {
    }
    public partial class ModelStyleService:BaseService<ModelStyle>,IModelStyleService
    {
        public ModelStyleService(IModelStyleRepository repository):base(repository){}
    }
}
