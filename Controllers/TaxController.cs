using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyingAndSellingRealEstateNordic.Contexts;
using BuyingAndSellingRealEstateNordic.Models;
using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using BuyingAndSellingRealEstateNordic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BuyingAndSellingRealEstateNordic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ITaxService _taxService;
        private readonly ITaxComputationService _taxComputationService;
        public TaxController(TaxDataContext context, IFileService fileService)
        {
            _fileService = fileService;
            _taxService = new TaxService(context);
            _taxComputationService = new TaxComputationService(_taxService);
        }

        [HttpPost]
        [Route("BulkTaxDataUpload")]
        public async Task<IActionResult> BulkTaxDataUpload(IFormFile taxinputfile)
        {
            var fileData = await _fileService.ReadFile(taxinputfile);
            if (string.IsNullOrEmpty(fileData))
            {
                return BadRequest("File can't be empty");
            }

            List<TaxData> taxData = JsonConvert.DeserializeObject<List<TaxData>>(fileData);

            if (taxData == null || taxData.Count == 0)
            {
                return BadRequest("File can't be empty");
            }

            await _taxService.AddTaxRecords(taxData);

            return Created(HttpContext.Request.Path, "Uploaded successfully");
        }

        [HttpPost]
        [Route("TaxDataUpload")]
        public async Task<IActionResult> TaxDataUpload([FromBody] TaxData taxData)
        {
            await _taxService.AddTaxRecord(taxData);
            return Created(HttpContext.Request.Path, "Uploaded successfully");
        }

        [HttpGet]
        [Route("GetTaxInfo")]
        public IActionResult GetTaxInfo(string city, DateTime date)
        {
            var taxCost = _taxComputationService.GetTaxInfo(city, date);
            if(taxCost == null)
            {
                return NotFound("No tax found for the selected city");
            }
            return Ok($"Tax cost of {city} for the date {date.ToString("yyyy-MM-dd")} is {taxCost}");
        }
    }
}
