using Microsoft.AspNetCore.Hosting;
using WebApplication.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}