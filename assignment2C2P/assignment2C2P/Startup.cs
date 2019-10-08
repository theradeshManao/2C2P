using System;
using System.Linq;
using assignment2C2P.Infrastructure.EF;
using assignment2C2P.Infrastructure.EF.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace assignment2C2P
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new assignment2C2P.IoC.StructureMap());
                config.Populate(services);
            });
            return container.GetInstance<IServiceProvider>();
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AssignmentDB>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API of 2C2P Assignment", Version = "v1" });
            });

            return this.ConfigureIoC(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AssignmentDB context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                if (!context.Customers.Any() && !context.Transactions.Any())
                {
                    CustomerSeeding.Seed(context);
                    TransactionSeeding.Seed(context);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
