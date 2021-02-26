using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ShowHttpRequestDetails
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("<head><title>Http request details</title></head><body>");
                    await context.Response.WriteAsync("<h3>Headers</h3>");
                    foreach (var header in context.Request.Headers)
                    {
                        await context.Response.WriteAsync($"<h4>{header.Key}</h4>");
                        await context.Response.WriteAsync($"<p>{header.Value}</p>");
                    }
                    await context.Response.WriteAsync("</body>");
                });
            });
        }
    }
}
