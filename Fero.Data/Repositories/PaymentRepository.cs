using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IPaymentRepository :IBaseRepository<Payment>
    {
    }
    public partial class PaymentRepository :BaseRepository<Payment>, IPaymentRepository
    {
         public PaymentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

