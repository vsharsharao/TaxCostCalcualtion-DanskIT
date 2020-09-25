using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Models.Interfaces
{
    public interface ITaxService
    {
        Task AddTaxRecord(TaxData taxData);
        Task AddTaxRecords(List<TaxData> taxDataList);
        TaxData GetTaxData(string city);
    }
}
