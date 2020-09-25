using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using BuyingAndSellingRealEstateNordic.Contexts;

namespace BuyingAndSellingRealEstateNordic.Services
{
    public class Logger : ILog
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly LoggerContext _context;
        public Logger(LoggerContext context)
        {
            _context = context;
        }
        public void Information(string message)
        {
            logger.Info(message);
        }
        public void Warning(string message)
        {
            logger.Warn(message);
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }
        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
