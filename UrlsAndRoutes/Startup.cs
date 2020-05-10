using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //applying custom constrain - inline
            services.Configure<RouteOptions>(options =>
                {
                    options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                    options.LowercaseUrls = true;
                   options.AppendTrailingSlash = true; //adds "/" at the end of generated URLs
                });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");
                

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "out",
                    template: "outbound/{controller=Home}/{action=Index}");
            });
            
            
            
            //app.UseMvcWithDefaultRoute();//it matches default path {controller}/{action}/{id?}
                        
            //commented this section to practice with Attribute routes

            //app.UseMvc(routes => {
            //    routes.MapRoute(name: "MyRoute",
            //    //custom constraint - inline
            //    template: "{controller=Home}/{action=Index}/{id:weekday?}");
  

                ////applying custom constraint - outside of URL
                //template: "{controller}/{action}/{id?}",
                //defaults: new {controller = "Home", action = "Index"},
                //constraints: new { id = new WeekDayConstraint() });

                ////multiple constraints
                //template: "{controller=Home}/{action=Index}"+"{id:alpha:minlength(6)?}");

                ////restricting useing regular expression
                ////displays only controller starts with H and action Index or About
                //template: "{controller:regex(^H.*)=Home}" + "{action:regex(^Index$|^About$)=Index}/{id?}");


                ////restricting what can be match against - Inline constraint (also can be specified outside of URL)
                //template: "{controller=Home}/{action=Index}/{id:int?}");

                ////catching all routes
                //template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");


                ////preserving old Shop url schema
                //routes.MapRoute(
                //    name: "ShopSchema",
                //    template: "Shop/{action}",
                //    defaults: new { controller = "Home" }
                //    );

                ////static and variable segments
                //routes.MapRoute("", "X{controller}/{action}");

                //routes.MapRoute(
                //    //Defining inline default values
                //    name: "default", template: "{controller=Home}/{action=Index}"

                //    //Defining defaults outside of the inline pattern
                //    //name: "default", template: "{controller}/{action}",
                //    //defaults: new { action = "Index"} //processes the url requests with single segment
                //    );

                ////static url segment
                //routes.MapRoute(
                //    name: "", template: "Public/{controller=Home}/{action=Index}");


            //});
        }
    }
}
