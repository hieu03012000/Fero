using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Model
    {
        public Model()
        {
            ApplyCasting = new HashSet<ApplyCasting>();
            BodyPart = new HashSet<BodyPart>();
            CashLevel = new HashSet<CashLevel>();
            ModelCasting = new HashSet<ModelCasting>();
            ModelStyle = new HashSet<ModelStyle>();
            Product = new HashSet<Product>();
            SubscribeCasting = new HashSet<SubscribeCasting>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubAddress { get; set; }
        public int? TotalFollowers { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Gifted { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<ApplyCasting> ApplyCasting { get; set; }
        public virtual ICollection<BodyPart> BodyPart { get; set; }
        public virtual ICollection<CashLevel> CashLevel { get; set; }
        public virtual ICollection<ModelCasting> ModelCasting { get; set; }
        public virtual ICollection<ModelStyle> ModelStyle { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SubscribeCasting> SubscribeCasting { get; set; }
    }
}
