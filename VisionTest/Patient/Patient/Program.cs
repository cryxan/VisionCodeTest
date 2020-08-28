using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Patient
{
    public class Program
    {
        public static bool testMode = false;
        public static void Main(string[] args)
        {
            String testModeCheck =  Environment.GetEnvironmentVariable("PATIENT_API_TEST_MODE");
            if (testModeCheck != null && testModeCheck == "TRUE")
            {
                testMode = true;
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
