﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BP.WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>();
        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {//removing default configuration options
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables();
        }
    }
}
