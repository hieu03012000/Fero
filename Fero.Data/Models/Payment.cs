using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal Amount { get; set; }
        public byte Status { get; set; }
        public int? ModelCastingId { get; set; }
        public int? PaymentAccountId { get; set; }

        public virtual ModelCasting ModelCasting { get; set; }
        public virtual PaymentAccount PaymentAccount { get; set; }
    }
}
