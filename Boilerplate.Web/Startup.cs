using Boilerplate.Data;
using Boilerplate.Data.Contracts;
using Boilerplate.Data.Domains;
using Boilerplate.Infrastructure.Contracts;
using Boilerplate.Infrastructure.Helpers;
using Boilerplate.Infrastructure.Storage;
using Boilerplate.Services.Contracts;
using Boilerplate.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Boilerplate.Web
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
            services.AddDbContext<BoilerplateDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("BoilerplateDbConnStr"), b => b.MigrationsAssembly("Boilerplate.Web"));
            });
            // Data
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Infrastructure
            services.AddTransient<ISqlQueryHelper, SqlQueryHelper>(crg =>
            {
                return new SqlQueryHelper(Configuration.GetConnectionString("BoilerplateDbConnStr"));
            });
            services.AddTransient<IStorageBlobProvider, StorageBlobProvider>(crg =>
            {
                return new StorageBlobProvider(Configuration["AzureSettings:StorageAccountConnString"], "$documents");
            });
            services.AddTransient<IClaimHelper, ClaimHelper>();            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountTransactionService, AccountTransactionService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction() || env.IsStaging())
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
            
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
