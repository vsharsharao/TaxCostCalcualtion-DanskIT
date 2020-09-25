using BuyingAndSellingRealEstateNordic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Contexts
{
    public class LoggerContext : DbContext
    {
        public LoggerContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<LogInfo> LogInfo { get; set; }
    }
}
