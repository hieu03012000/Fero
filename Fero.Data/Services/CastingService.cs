using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ICastingService:IBaseService<Casting>
    {
    }
    public partial class CastingService:BaseService<Casting>,ICastingService
    {
        public CastingService(ICastingRepository repository):base(repository){}
    }
}
