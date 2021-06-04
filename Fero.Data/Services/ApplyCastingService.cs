using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IApplyCastingService:IBaseService<ApplyCasting>
    {
    }
    public partial class ApplyCastingService:BaseService<ApplyCasting>,IApplyCastingService
    {
        public ApplyCastingService(IApplyCastingRepository repository):base(repository){}
    }
}
