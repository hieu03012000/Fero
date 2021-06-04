using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBodyAttributeService:IBaseService<BodyAttribute>
    {
    }
    public partial class BodyAttributeService:BaseService<BodyAttribute>,IBodyAttributeService
    {
        public BodyAttributeService(IBodyAttributeRepository repository):base(repository){}
    }
}
