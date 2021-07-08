using System;
using System.Collections.Generic;

namespace Fero.Data.ViewModels
{
    public class CastingListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public byte Status { get; set; }
    }

    public class CastingListIds
    {
        public List<int> CastingIds { get; set; }
    }
}
