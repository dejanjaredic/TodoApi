using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TodoApi
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
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Todo Api",
                    Version = "v1",
                    Description = "A simple Web app for bild",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Dejan Jaredic",
                        Email = string.Empty,
                        Url = "https://jaredicdejan.com"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseMvc(routes =>
            {
                /*routes.MapAreaRoute("test", "test/{*listall}",
                    defaults: new  { controller = "Test", action = "ListAll"});*/
               //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); 
                
            });
            // OR app.UseMvcWithDefaultRoute()


        }
    }
}
