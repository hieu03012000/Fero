using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ICashLevelService:IBaseService<CashLevel>
    {
    }
    public partial class CashLevelService:BaseService<CashLevel>,ICashLevelService
    {
        public CashLevelService(ICashLevelRepository repository):base(repository){}
    }
}
