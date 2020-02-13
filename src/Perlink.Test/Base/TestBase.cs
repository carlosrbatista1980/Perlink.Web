using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Perlink.Data;
using Perlink.Services;
using Xunit;
using Perlink.Web;

namespace Perlink.Test.Base
{
    public abstract class TestBase : IClassFixture<Startup>
    {
        public Startup _statup;
        public IConfiguration _configuration;

        public TestBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _statup = new Startup(_configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(opt =>
            {
            });
            
            services.AddDbContext<PerlinkDbContext>(options =>
            {
                //options.UseMySql(Configuration.GetConnectionString("Default"));
                options.UseInMemoryDatabase(_configuration.GetConnectionString("Default"));
            });
            services.AddScoped<MainService>();
        }
    }
}
