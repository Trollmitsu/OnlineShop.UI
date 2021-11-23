using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.DataAccess;
using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop
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
            services.AddSingleton<IDataAccess<CardDTO>, CardDataAccess>();
            services.AddSingleton<IDataSource<CardDTO>, CardDataSource>();
            services.AddSingleton<IDataAccess<CustomerDTO>, CustomerDataAccess>();
            services.AddSingleton<IDataSource<CustomerDTO>, CustomerDataSource>();
            services.AddSingleton<IDataAccess<ProductDTO>, ProductDataAccess>();
            services.AddSingleton<IDataSource<ProductDTO>, ProductDataSource>();
            services.AddSingleton<IDataAccess<OrderDTO>, OrderDataAccess>();
            services.AddSingleton<IDataSource<OrderDTO>, OrderDataSource>();
            services.AddSingleton<IDataAccess<RecieptDTO>, RecieptDataAccess>();
            services.AddSingleton<IDataSource<RecieptDTO>, RecieptDataSource>();
            services.AddSingleton<IDataAccess<ShoppingCartDTO>, ShoppingCartDataAccess>();
            services.AddSingleton<IDataSource<ShoppingCartDTO>, ShoppingCartDataSource>();

            services.AddRazorPages();
            services.AddSession();
            services.AddMemoryCache();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
