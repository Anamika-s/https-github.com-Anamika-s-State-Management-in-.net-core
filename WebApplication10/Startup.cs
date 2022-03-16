using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication10.ExtensionMethods;

namespace WebApplication10
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Test>();
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseFileServer();

            app.UseSession();
            app.UseRouting();
           
            app.UseAuthorization();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 1");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("1st Hello from Use");
            //    await next();
            //    await context.Response.WriteAsync("2nd hello from Use");
            //});
            //app.Map("/newbranch", a=>a.Run(c=>c.Response.WriteAsync("Running from New Branch")));
            app.Map("/newbranch", a =>
           {
               a.Map("/branch1", brancha => brancha
               .Run(c => c.Response.WriteAsync("This if from branch1 in newbranch")));
               a.Map("/branch2", brancha => brancha
            .Run(c => c.Response.WriteAsync("This if from branch2 in newbranch")));

           });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
         

    }
}
