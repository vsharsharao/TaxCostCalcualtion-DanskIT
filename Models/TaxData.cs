using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Models
{
    public class TaxData
    {
        public long TaxDataId { get; set; }
        public string City { get; set; }
        public List<TaxSchedule> Schedule { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn => DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
