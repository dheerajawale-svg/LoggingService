using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Serilog;

namespace Natus.Logging.Service
{
    public class Program
    {
        private const string Init = "Logging Service is Up & Running";

        public static void Main(string[] args)
        {
            var options = new WebApplicationOptions
            {
                Args = args,
                ApplicationName = typeof(Program).Assembly.GetName().Name,
                ContentRootPath = WindowsServiceHelpers.IsWindowsService()
                                  ? AppContext.BaseDirectory : default
            };

            var builder = WebApplication.CreateBuilder(options);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Serilog Init
            var _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.AddSerilog(_logger);
            
            builder.Host.UseWindowsService(options =>
            {
                options.ServiceName = typeof(Program).Assembly.GetName().Name;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors((policyBuilder) =>
            {
                policyBuilder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
            });

            app.MapControllers();

            app.MapGet("/", () => { return Init; });

            app.Run();
        }
    }
}