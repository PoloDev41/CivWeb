using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebCiv.Configuration;
using WebCiv.DAL;

[assembly: HostingStartup(typeof(WebCiv.Areas.Identity.IdentityHostingStartup))]
namespace WebCiv.Areas.Identity
{
    /// <summary>
    /// class for Identity hosting startup
    /// </summary>
    public class IdentityHostingStartup : IHostingStartup
    {
        /// <summary>
        /// constructor of Identity hosting startup
        /// </summary>
        /// <param name="builder">builder</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Don't care, auto code")]
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}