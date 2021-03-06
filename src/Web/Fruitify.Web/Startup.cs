﻿namespace Fruitify.Web
{
    using System.Reflection;

    using CloudinaryDotNet;

    using Fruitify.Data;
    using Fruitify.Data.Common;
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Data.Repositories;
    using Fruitify.Data.Seeding;
    using Fruitify.Services.Data;
    using Fruitify.Services.Data.Administration;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Services.Messaging;
    using Fruitify.Services.Models.Administration.Products;
    using Fruitify.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddServerSideBlazor();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Cloudinary Api set
            Account cloudinaryCredentials = new Account(
                                        this.configuration["Cloudinary:CloudName"],
                                        this.configuration["Cloudinary:ApiKey"],
                                        this.configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinary);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IReceiptsService, ReceiptsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(ProductServiceInputModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder(this.configuration).SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapBlazorHub();
                        endpoints.MapRazorPages();
                    });
        }
    }
}
