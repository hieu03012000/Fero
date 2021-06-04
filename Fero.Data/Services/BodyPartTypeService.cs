using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBodyPartTypeService:IBaseService<BodyPartType>
    {
    }
    public partial class BodyPartTypeService:BaseService<BodyPartType>,IBodyPartTypeService
    {
        public BodyPartTypeService(IBodyPartTypeRepository repository):base(repository){}
    }
}
