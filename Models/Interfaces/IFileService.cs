using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyingAndSellingRealEstateNordic.Models.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadFile(IFormFile file);
    }
}
