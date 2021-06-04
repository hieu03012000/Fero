using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IModelService:IBaseService<Model>
    {
    }
    public partial class ModelService:BaseService<Model>,IModelService
    {
        public ModelService(IModelRepository repository):base(repository){}
    }
}
