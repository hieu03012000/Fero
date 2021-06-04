using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IStyleService:IBaseService<Style>
    {
    }
    public partial class StyleService:BaseService<Style>,IStyleService
    {
        public StyleService(IStyleRepository repository):base(repository){}
    }
}
