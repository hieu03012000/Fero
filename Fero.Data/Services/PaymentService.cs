using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IPaymentService:IBaseService<Payment>
    {
    }
    public partial class PaymentService:BaseService<Payment>,IPaymentService
    {
        public PaymentService(IPaymentRepository repository):base(repository){}
    }
}
