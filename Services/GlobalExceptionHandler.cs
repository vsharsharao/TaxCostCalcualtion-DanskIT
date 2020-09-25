using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Services
{
    public class GlobalExcpetionHandler
    {
        private readonly HttpContext _htttpContext;
        private readonly ILog _logger;
        public GlobalExcpetionHandler(HttpContext htttpContext, ILog logger)
        {
            _htttpContext = htttpContext;
            _logger = logger;
        }

        public void LogServerError()
        {
            var err = _htttpContext.Features.Get<IExceptionHandlerFeature>();
            if (err != null)
            {
                _logger.Error($"Error Message : {err.Error.Message}\r\nStacktrace : {err.Error.StackTrace}");
            }
        }
    }
}
