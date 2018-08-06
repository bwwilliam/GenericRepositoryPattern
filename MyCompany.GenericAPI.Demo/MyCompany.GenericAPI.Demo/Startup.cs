using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyCompany.GenericAPI.DAL;
using MyCompany.GenericAPI.DAL.Models;

using Microsoft.EntityFrameworkCore;


namespace MyCompany.GenericAPI.Demo
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
           services.AddMvc();

            var connection = @"Server=.;Database=Temp;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddEntityFrameworkSqlServer()
                       .AddDbContext<TempContext>((serviceProvider, options) => options.UseSqlServer(connection)
                       .UseInternalServiceProvider(serviceProvider));

            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
