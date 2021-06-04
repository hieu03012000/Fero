using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IBodyPartService:IBaseService<BodyPart>
    {
    }
    public partial class BodyPartService:BaseService<BodyPart>,IBodyPartService
    {
        public BodyPartService(IBodyPartRepository repository):base(repository){}
    }
}
