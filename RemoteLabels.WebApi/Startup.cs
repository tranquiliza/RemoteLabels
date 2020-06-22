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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RemoteLabels.Core;
using RemoteLabels.FileSystem;
using RemoteLabels.Sql;

namespace RemoteLabels.WebApi
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
            services.AddControllers();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IPositionRepository, PositionRepository>();
            services.AddSingleton<IPositionService, PositionService>();
            services.AddSingleton<ILabelRepository, LabelRepository>();
            services.AddSingleton<IApplicationSettings, ApplicationSettings>();

            var connProvider = new ConnectionStringProvider(@"Data Source=localhost\sqlexpress;Initial Catalog=StreamLabelApiDevelopment;Integrated Security=True");
            services.AddSingleton<IConnectionStringProvider>(connProvider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
