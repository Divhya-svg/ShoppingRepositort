using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KaniniEShoppingAPI.Orders;
using KaniniEShoppingAPI.Payment;
using KaniniEShoppingAPI.Product;
using KaniniEShoppingAPI.ProductSearch;
using KaniniEShoppingAPI.Shipping;
using KaniniEShoppingAPI.User;
using KaniniEShoppingAPI.UserLogin;
using KaniniEShoppingAPI.UserRole;
using KaniniEShoppingAPI.WishList;
using KaniniEShoppingAPI.Orders;
using KaniniEShoppingAPI.Payment;
using KaniniEShoppingAPI.Product;
using KaniniEShoppingAPI.ProductSearch;
using KaniniEShoppingAPI.Repository;
using KaniniEShoppingAPI.Shipping;
using KaniniEShoppingAPI.User;
using KaniniEShoppingAPI.UserLogin;
using KaniniEShoppingAPI.UserRole;
using KaniniEShoppingAPI.WishList;
using KaniniEShoppingAPI.Services;
using KaniniEShoppingAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Kanini.ECommerce.EShopiee.DAL.Images;
using Kanini.ECommerce.EShopiee.BL.Images;

namespace KaniniEShoppingAPI
{
    public class Startup
    {
        private readonly string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    this.myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // configure strongly typed settings objects
            var appSettingSection = this.Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            // configure jwt authentication
            var appSettings = appSettingSection.Get<AppSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            // Configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IUserLoginRepo, UserLoginRepo>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IImageRepo, ImageRepo>();
            services.AddTransient<IBaseRepo, BaseRepo>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IWishListRepository, WishListRepository>();
            services.AddTransient<IWishListRepo, WishListRepo>();
            services.AddTransient<ISearchProductRepository, SearchProductRepository>();
            services.AddTransient<ISearchProduct, SearchProductBl>();
            services.AddTransient<IPaymentRepo, PaymentRepo>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IShippingRepository, ShippingRepository>();
            services.AddTransient<IShippingRepo, ShippingRepo>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IOrdersRepo, OrdersRepo>();
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
            app.UseHttpsRedirection();
            app.UseCors(this.myAllowSpecificOrigins);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            
            app.UseMvc();
        }
    }
}
