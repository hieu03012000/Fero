using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ITattooService:IBaseService<Tattoo>
    {
    }
    public partial class TattooService:BaseService<Tattoo>,ITattooService
    {
        public TattooService(ITattooRepository repository):base(repository){}
    }
}
