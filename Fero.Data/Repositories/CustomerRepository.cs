using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface ICustomerRepository :IBaseRepository<Customer>
    {
    }
    public partial class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
         public CustomerRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

