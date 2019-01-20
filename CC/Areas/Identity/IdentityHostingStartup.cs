using System;
using CC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CC.Areas.Identity.IdentityHostingStartup))]
namespace CC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<GroupDataContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cc;Trusted_Connection=true;"));

                       // context.Configuration.GetConnectionString("CCContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<GroupDataContext>();
                services.AddAuthentication().AddGoogle(googleOptions =>
                {
                    googleOptions.ClientSecret = "McndcKJPMu7hjOxL4FsXUo8n";
                    googleOptions.ClientId = "859553687868-drlc8ikj2smnlp75mmojn9lgu656d4hr.apps.googleusercontent.com";
                });
            });

        }
    }
}