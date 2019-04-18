using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace apiBooksStore
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration)
            //    .CreateLogger();

            ColumnOptions columnOptions = new ColumnOptions();
            // Don't include the Properties XML column.
            columnOptions.Store.Remove(StandardColumn.Properties);
            // Do include the log event data as JSON.
            columnOptions.Store.Add(StandardColumn.LogEvent);
            // Add additional VerificationCode column
            columnOptions.AdditionalDataColumns = new Collection<DataColumn>
            {
            new DataColumn {DataType = typeof (string), ColumnName = "VerificationCode"},
            };

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.MSSqlServer(Configuration.GetConnectionString("BooksStoreDB"), "Log", autoCreateSqlTable: true, columnOptions: columnOptions, schemaName: "Logging")
           .CreateLogger();

            

            try
            {
                Log.Information("Host starting...");

               // CreateWebHostBuilder(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }



        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseConfiguration(Configuration)
        //        .UseSerilog()
        //        .UseStartup<Startup>();


        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseSerilog()
                .UseStartup<Startup>();
        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //           .UseStartup<Startup>()
        //           .UseConfiguration(Configuration)
        //           .UseSerilog()
        //           .Build();
    }
}
