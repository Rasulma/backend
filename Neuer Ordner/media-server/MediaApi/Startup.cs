using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediaApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // MVC-Dienste hinzufügen
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Entwicklermodus
            }

            app.UseRouting(); // Middleware für Routing aktivieren

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Controller-Routen einrichten
            });
        }
    }
}