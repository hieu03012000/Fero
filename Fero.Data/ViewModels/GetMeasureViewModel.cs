using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class GetMeasureViewModel
    {
        public int Id { get; set; }
        public decimal? Value { get; set; }
        public int? BodyAttTypeId { get; set; }
        public int? BodyPartId { get; set; }
        public string BodyAttName { get; set; }
        public string BodyPartName { get; set; }
        public string Measure { get; set; }
    }


    public class UpdateMeasureViewModel
    {
        public int Id { get; set; }
        public decimal? Value { get; set; }
        public int? BodyAttTypeId { get; set; }
        public int? BodyPartId { get; set; }

    }
}
