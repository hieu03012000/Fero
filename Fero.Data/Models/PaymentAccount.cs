using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class PaymentAccount
    {
        public PaymentAccount()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal? AccountNumber { get; set; }
        public DateTime? ExpDate { get; set; }
        public string VertificaionCode { get; set; }
        public byte Status { get; set; }
        public string UserId { get; set; }
        public int? PaymentTypeId { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
