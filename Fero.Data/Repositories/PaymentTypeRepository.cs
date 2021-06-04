using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IPaymentTypeRepository :IBaseRepository<PaymentType>
    {
    }
    public partial class PaymentTypeRepository :BaseRepository<PaymentType>, IPaymentTypeRepository
    {
         public PaymentTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

