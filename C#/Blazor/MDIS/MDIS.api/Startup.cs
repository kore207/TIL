using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDIS.api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Serialization;


namespace MDIS.api
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
            services.AddDbContext<MDISDBContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IDronRepository, DronRepository>();
            services.AddScoped<IFlyingRepository, FlyingRepository>();

            services.AddCors(o =>
            {
                o.AddPolicy(name: "mypolicy", builder =>
                 {
                     builder.WithOrigins("http://localhost:56728",
                         "http://localhost:53572");
                 });
            });

            services.AddControllers();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseCors("mypolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
