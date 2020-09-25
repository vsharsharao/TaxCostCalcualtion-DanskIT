using System;

namespace BuyingAndSellingRealEstateNordic.Models
{
    public class ScheduleRange
    {
        public long ScheduleRangeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}