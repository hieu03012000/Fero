using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IPaymentAccountService:IBaseService<PaymentAccount>
    {
    }
    public partial class PaymentAccountService:BaseService<PaymentAccount>,IPaymentAccountService
    {
        public PaymentAccountService(IPaymentAccountRepository repository):base(repository){}
    }
}
