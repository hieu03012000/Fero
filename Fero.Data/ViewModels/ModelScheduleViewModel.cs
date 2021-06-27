using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class ModelScheduleViewModel
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public byte Status { get; set; }
        public int? CastingId { get; set; }
        public string CastingName { get; set; }
        public string ModelId { get; set; }
    }
}
