using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IPaymentAccountRepository :IBaseRepository<PaymentAccount>
    {
    }
    public partial class PaymentAccountRepository :BaseRepository<PaymentAccount>, IPaymentAccountRepository
    {
         public PaymentAccountRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

