using BuyingAndSellingRealEstateNordic.Contexts;
using BuyingAndSellingRealEstateNordic.Models;
using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Services
{
    public class TaxService : ITaxService
    {
        private readonly TaxDataContext _context;
        public TaxService(TaxDataContext context)
        {
            _context = context;
        }
        public async Task AddTaxRecord(TaxData taxData)
        {
            var taxDataContext = _context.TaxData.Where(i => i.City == taxData.City).FirstOrDefault();
            if(taxDataContext != null)
            {
                _context.TaxData.Remove(taxDataContext);
            }
            _context.TaxData.Add(taxData);

            await _context.SaveChangesAsync();
        }

        public async Task AddTaxRecords(List<TaxData> taxDataList)
        {
            _context.TaxData.AddRange(taxDataList);
            await _context.SaveChangesAsync();
        }

        public TaxData GetTaxData(string city)
        {
            return _context.TaxData
                .Include(i => i.Schedule)
                .ThenInclude(s => s.ScheduleRanges)
                .AsEnumerable().Where(i => i.IsActive && i.City.Equals(city, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault();
        }
    }
}
