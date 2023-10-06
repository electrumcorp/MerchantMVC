using MerchantMVC.Models;
using MerchantMVC.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MerchantMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Testing;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
              .AddRazorRuntimeCompilation();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                ;
            services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(60));
            services.AddDbContext<EbaseDBContext>();
            services.AddControllersWithViews();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILoyaltyTranRepository, LoyaltyTranRepository>();
            services.AddScoped<ICallTrackingRepository, CallTrackingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<IMerchantProfileRepository, MerchantProfileRepository>();
            services.AddScoped<IFeedBackRepository, FeedbackRepository>();
            services.AddScoped<ILocationProfileRepository, LocationProfileRepository>();
            //services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
