using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanEmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DanEmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvcCore(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hi there I am Server Dan!");
            });

        }
    }
}
// To add foo file like deff 
//FileServerOptions fileServerOptions = new FileServerOptions();
//fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
//fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
//app.UseFileServer(fileServerOptions);


// How to show deff files in web browser and how to change other file to deff !
//DefaultFilesOptions deffFilesOption = new DefaultFilesOptions();
//deffFilesOption.DefaultFileNames.Clear();
//deffFilesOption.DefaultFileNames.Add("foo.html");
//app.UseDefaultFiles(deffFilesOption);

//// To vizualize images !
//app.UseStaticFiles();