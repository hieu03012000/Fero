using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IPaymentTypeService:IBaseService<PaymentType>
    {
    }
    public partial class PaymentTypeService:BaseService<PaymentType>,IPaymentTypeService
    {
        public PaymentTypeService(IPaymentTypeRepository repository):base(repository){}
    }
}
