using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Casting = new HashSet<Casting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int? BrandCateId { get; set; }

        public virtual BrandCategory BrandCate { get; set; }
        public virtual ICollection<Casting> Casting { get; set; }
    }
}
