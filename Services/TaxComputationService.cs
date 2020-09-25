using BuyingAndSellingRealEstateNordic.Models;
using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Services
{
    public class TaxComputationService : ITaxComputationService
    {
        private readonly ITaxService _taxService;
        public TaxComputationService(ITaxService taxService)
        {
            _taxService = taxService;
        }
        public decimal? GetTaxInfo(string city, DateTime date)
        {
            decimal? taxCost = null;
            TaxData taxData = _taxService.GetTaxData(city);
            var dailySchedule = taxData.Schedule.Where(i => i.ScheduleType.Equals(ScheduleType.Daily)).FirstOrDefault();
            var weeklySchedule = taxData.Schedule.Where(i => i.ScheduleType.Equals(ScheduleType.Weekly)).FirstOrDefault();
            var monthlySchedule = taxData.Schedule.Where(i => i.ScheduleType.Equals(ScheduleType.Monthly)).FirstOrDefault();
            var yearlySchedule = taxData.Schedule.Where(i => i.ScheduleType.Equals(ScheduleType.Yearly)).FirstOrDefault();

            if (dailySchedule != null && CheckIfDateInRange(dailySchedule, date))
            {
                return dailySchedule.TaxCost;
            }

            else if (weeklySchedule != null && CheckIfDateInRange(weeklySchedule, date))
            {
                return weeklySchedule.TaxCost;
            }

            else if (monthlySchedule != null && CheckIfDateInRange(monthlySchedule, date))
            {
                return monthlySchedule.TaxCost;
            }

            else if (yearlySchedule != null && CheckIfDateInRange(yearlySchedule, date))
            {
                return yearlySchedule.TaxCost;
            }

            return taxCost;
        }

        private bool CheckIfDateInRange(TaxSchedule schedule, DateTime date)
        {
            return schedule.ScheduleRanges.Any(i => date.Date.Ticks >= i.StartDate.Date.Ticks && date.Date.Ticks <= i.EndDate.Date.Ticks);
        }
    }
}
