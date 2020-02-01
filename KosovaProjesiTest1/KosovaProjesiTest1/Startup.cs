using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using KosovaProjesiTest1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KosovaProjesiTest1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicatonIdentityDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
           );
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicatonIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddLocalization(options =>
            {
                // Resource (kaynak) dosyalarımızı ana dizin altında "Resources" klasorü içerisinde tutacağımızı belirtiyoruz.
                options.ResourcesPath = "Resources";
            });
            services
                .AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            // Bu bölüm UseMvc()' den önce eklenecektir.
            // Uygulamamız içerisinde destek vermemizi istediğimiz dilleri tutan bir liste oluşturuyoruz.
            var supportedCultures = new List<CultureInfo>
            {
            new CultureInfo("tr-TR"),
            new CultureInfo("en-US"),
            new CultureInfo("sq-AL"),
            };
                        // SupportedCultures ve SupportedUICultures'a yukarıda oluşturduğumuz dil listesini tanımlıyoruz.
            // DefaultRequestCulture'a varsayılan olarak uygulamamızın hangi dil ile çalışması gerektiğini tanımlıyoruz.
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture("tr-TR")
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
