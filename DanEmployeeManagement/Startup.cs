using DanEmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanEmployeeManagement
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(mvcoptions => mvcoptions.EnableEndpointRouting = false)
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {

                routes.MapRoute("default", "{controller=Home}/{action=Details}/{id=2}");
            });
        }
    }
}