using BuyingAndSellingRealEstateNordic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Contexts
{
    public class TaxDataContext : DbContext
    {
        public TaxDataContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<TaxData> TaxData { get; set; }
    }
}
