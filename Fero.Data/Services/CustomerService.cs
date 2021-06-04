using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface ICustomerService:IBaseService<Customer>
    {
    }
    public partial class CustomerService:BaseService<Customer>,ICustomerService
    {
        public CustomerService(ICustomerRepository repository):base(repository){}
    }
}
