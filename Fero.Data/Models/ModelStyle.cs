using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class ModelStyle
    {
        public string ModelId { get; set; }
        public int StyleId { get; set; }

        public virtual Model Model { get; set; }
        public virtual Style Style { get; set; }
    }
}
