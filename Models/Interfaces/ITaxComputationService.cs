using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Models.Interfaces
{
    public interface ITaxComputationService
    {
        decimal? GetTaxInfo(string city, DateTime date);
    }
}
