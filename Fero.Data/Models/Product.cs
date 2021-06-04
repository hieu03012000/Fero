using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string ModelId { get; set; }

        public virtual Model Model { get; set; }
    }
}
