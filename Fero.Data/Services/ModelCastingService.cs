using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IModelCastingService:IBaseService<ModelCasting>
    {
    }
    public partial class ModelCastingService:BaseService<ModelCasting>,IModelCastingService
    {
        public ModelCastingService(IModelCastingRepository repository):base(repository){}
    }
}
