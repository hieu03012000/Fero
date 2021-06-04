using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IStaffService:IBaseService<Staff>
    {
    }
    public partial class StaffService:BaseService<Staff>,IStaffService
    {
        public StaffService(IStaffRepository repository):base(repository){}
    }
}
