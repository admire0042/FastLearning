using System;
using FastLearning.Areas.Identity.Data;
using FastLearning.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FastLearning.Areas.Identity.IdentityHostingStartup))]
namespace FastLearning.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FastLearningContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FastLearningContextConnection")));

                services.AddDefaultIdentity<LoginUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<FastLearningContext>();
            });
        }
    }
}