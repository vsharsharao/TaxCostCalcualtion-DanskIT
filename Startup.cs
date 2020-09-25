using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BuyingAndSellingRealEstateNordic.Contexts;
using BuyingAndSellingRealEstateNordic.Models;
using BuyingAndSellingRealEstateNordic.Models.Interfaces;
using BuyingAndSellingRealEstateNordic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BuyingAndSellingRealEstateNordic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IFileService, FileService>();
            //services.AddSingleton<ILog, Logger>();
            services.AddDbContext<TaxDataContext>(i => i.UseSqlite(Configuration.GetConnectionString("SqlLiteProvider")));            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(options => options.Run(async context =>
            {
                //new GlobalExcpetionHandler(
                //    context,
                //    logger)
                //.LogServerError();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("An error occurred while processing the request.");
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
