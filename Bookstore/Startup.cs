using Bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //added services that load the database to connect with the website
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BooksConnection"]);
            });

            services.AddScoped<BooksRepository, EFBooksRepository>();

            //add in razor page functionality
            services.AddRazorPages();
            // services to create cart functionality
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //to start a cart session for user
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //setting end points and changing the URL use and output
            app.UseEndpoints(endpoints =>
            {
                //creating new endpoint paths for the page and category
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "/{page:int}",
                    new { Controller = "Home", action = "Index"});

                endpoints.MapControllerRoute("category",
                  "{category}",
                  new { Controller = "Home", action = "Index", page = 1});

                endpoints.MapControllerRoute(
                    "pagination",
                    "/P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //routing for razor pages
                endpoints.MapRazorPages();

            });

            //checks if database is populated
            SeedData.EnsurePopulated(app);
        }
    }
}
