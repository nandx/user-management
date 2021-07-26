using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using user_management.Config;
using user_management.Dao;
using user_management.Dao.Common;
using user_management.Dao.Impl;
using user_management.Model;

namespace user_management
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "user_management", Version = "v1"});
            });
            var connStr = Configuration.GetConnectionString("MysqlConnection");

            // add NHibernate configuration
            services.AddNHibernate(connStr);
            
            // dependencies for the project
            services.AddScoped<IAppUserDao, AppUserDaoImpl>();
            services.AddScoped<ICommonDao< AppUser>, CommonDaoImpl<AppUser>>();
            services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();
        }
        
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "user_management v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}