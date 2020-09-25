using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using BuyingAndSellingRealEstateNordic.Models.Interfaces;

namespace BuyingAndSellingRealEstateNordic.Services
{
    public class FileService : IFileService
    {
        public async Task<string> ReadFile(IFormFile file)
        {
            string data = string.Empty;
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                data = await stream.ReadToEndAsync();
            }

            return data;
        }
    }
}
