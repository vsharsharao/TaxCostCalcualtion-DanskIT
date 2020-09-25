using System;
using System.Collections.Generic;

namespace BuyingAndSellingRealEstateNordic.Models
{
    public class TaxSchedule
    {
        public long TaxScheduleId { get; set; }
        public string ScheduleType { get; set; }
        public List<ScheduleRange> ScheduleRanges { get; set; }
        public decimal TaxCost { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}