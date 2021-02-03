using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectStatusAPI.Exceptions.API;
using ProjectStatusAPI.Exceptions.Data;
using ProjectStatusAPI.Storage;
using ProjectStatusAPI.Storage.DataPoint;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DataContext>();
            services.AddSingleton<IProjectRepository, DbProjectRepository>();
            services.AddSingleton<IDataPointRepository, DbDataPointRepository>();
            
            services.AddControllers();
            services.AddControllers(options =>
            {
                options.Filters.Add(new DataAccessExceptionFilter());
                options.Filters.Add(new HttpResponseExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}