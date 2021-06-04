using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBodyAttributeTypeService:IBaseService<BodyAttributeType>
    {
    }
    public partial class BodyAttributeTypeService:BaseService<BodyAttributeType>,IBodyAttributeTypeService
    {
        public BodyAttributeTypeService(IBodyAttributeTypeRepository repository):base(repository){}
    }
}
