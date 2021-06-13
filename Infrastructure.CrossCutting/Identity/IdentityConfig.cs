using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hamporsesh.Infrastructure.CrossCutting.Identity
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<MainContext>()
                .AddDefaultTokenProviders();


            services.AddAuthorization(options =>
            {
                //options.AddPolicy("TallPeopleonly", policy => policy.RequireClaim("height", "187"));
            });



            //identity options customization
            services.Configure<IdentityOptions>(options =>
            {
                configuration.GetSection("Identity:Options").Bind(options);
            });

            services.ConfigureApplicationCookie(options =>
            {

                // Cookie settings
                options.Cookie.HttpOnly = true;
                // options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.Name = $".AspNetCore.Identity.{configuration["ApplicationName"]}";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(25);
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                //options.SlidingExpiration = true;
            });
























            //  services.AddIdentity<User, Role>()
            //      .AddEntityFrameworkStores<MainContext>()
            //      .AddDefaultTokenProviders();
            // // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            // // services.AddAuthorization(options => { });
            //
            //  //identity options customization
            //  services.Configure<IdentityOptions>(options =>
            //  {
            //     // configuration.GetSection("Identity:Options").Bind(options);
            //  });
            //
            //  services.ConfigureApplicationCookie(options =>
            //  {
            //      // Cookie settings
            //      options.Cookie.HttpOnly = true;
            //      // options.Cookie.SameSite = SameSiteMode.Lax;
            //      options.Cookie.Name = $".AspNetCore.Identity.Hamporsesh";
            //      options.ExpireTimeSpan = TimeSpan.FromMinutes(25);
            //      options.LoginPath = "/Login";
            //      options.AccessDeniedPath = "/Accounts/AccessDenied";
            //      //options.SlidingExpiration = true;
            //  });
        }

    }
}
