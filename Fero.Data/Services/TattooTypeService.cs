using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ITattooTypeService:IBaseService<TattooType>
    {
    }
    public partial class TattooTypeService:BaseService<TattooType>,ITattooTypeService
    {
        public TattooTypeService(ITattooTypeRepository repository):base(repository){}
    }
}
