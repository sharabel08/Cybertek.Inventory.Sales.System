using System;
using Cybertek.Auth.Areas.Identity.Data;
using Cybertek.Auth.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Cybertek.Auth.Areas.Identity.IdentityHostingStartup))]
namespace Cybertek.Auth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CybertekAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CybertekAuthContextConnection")));

                services.AddDefaultIdentity<CybertekAuthUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CybertekAuthContext>();
            });
        }
    }
}