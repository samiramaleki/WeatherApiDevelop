using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Extentions
{
    public static class HostBuilderExtensions
    {
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args)
        //        .UseSerilog((hostingContext, loggerConfiguration) =>
        //            loggerConfiguration.Enrich.FromLogContext().ReadFrom.Configuration(hostingContext.Configuration)
        //            .WriteTo.Sentry(s =>
        //            {
        //                s.MinimumBreadcrumbLevel = LogEventLevel.Debug;
        //                s.MinimumEventLevel = LogEventLevel.Error;
        //            }))
        //        .UseSentry()
        //        .UseStartup<Startup>();
        //}
    }
}
