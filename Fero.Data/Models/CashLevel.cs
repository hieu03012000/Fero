using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class CashLevel
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public decimal Price { get; set; }
        public string ModelId { get; set; }

        public virtual Model Model { get; set; }
    }
}
