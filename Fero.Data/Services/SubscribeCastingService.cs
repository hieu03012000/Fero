using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ISubscribeCastingService:IBaseService<SubscribeCasting>
    {
    }
    public partial class SubscribeCastingService:BaseService<SubscribeCasting>,ISubscribeCastingService
    {
        public SubscribeCastingService(ISubscribeCastingRepository repository):base(repository){}
    }
}
