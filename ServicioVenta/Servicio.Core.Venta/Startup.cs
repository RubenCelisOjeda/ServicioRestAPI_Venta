using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servicio.Core.Entity;
using Servicio.Core.Venta.ConfigService;
using System.Globalization;

namespace Servicio.Core.Venta
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
            //cadena de conexion
            string connecionString = string.Empty;
            connecionString = Configuration.GetSection("AppeSettings:cn").Value;
            ConnectionString.Connection = connecionString;

            //Inyeccion de depencias para acceder a los metodos creados en la interfaces
            IoC.AddRegistration(services);

            var supportedCultures = new[]
            {
                "en-US"
            }; 

            var localizationOptions = new RequestLocalizationOptions();
            localizationOptions.AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures)
                .SetDefaultCulture(supportedCultures[0]);

            services.AddSingleton(localizationOptions);;

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("en-US"),
            };

            var modified = new CultureInfo("en-US");
            modified.NumberFormat.CurrencySymbol = "PEN";
            modified.NumberFormat.CurrencyDecimalDigits = 2;
            modified.NumberFormat.CurrencyDecimalSeparator = ".";
            modified.NumberFormat.CurrencyGroupSeparator = ",";

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(modified),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
