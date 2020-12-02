using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
 
namespace MvcMovie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();
            services.AddControllersWithViews();
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseStaticFiles();

            app.UseRouting();
 
            app.Use(
                async(context,next) => 
                {
                    Endpoint endPoint = context.GetEndpoint();    
                    if(endPoint != null) {
                        var routePattern = (endPoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

                        Debug.WriteLine($"Endpoint Name: {endPoint.DisplayName}");
                        Debug.WriteLine($"Route pattern: {routePattern}");

                        await next();
                    }
                    else 
                    {
                        Debug.WriteLine("EndPoint: null");
                        await context.Response.WriteAsync("Endpoint is not defined");
                    }
                }
            );
            app.UseEndpoints(
                endpoints => {                    
                        
                    endpoints.MapControllerRoute(
                        name: "default", 
                        pattern : "{controller=Home}/{action=Index1}/{id?}");                                       

                }
            );

        }
    }
}