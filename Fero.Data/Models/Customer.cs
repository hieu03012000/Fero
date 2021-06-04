using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Casting = new HashSet<Casting>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Web { get; set; }
        public string TaxCode { get; set; }
        public string Fanpage { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public bool? IsOutside { get; set; }
        public bool? Status { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Casting> Casting { get; set; }
    }
}
