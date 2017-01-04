using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using WindLog.Models;
using Microsoft.Framework.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WindLog.Models.Mappers;
using AutoMapper;

namespace WindLog
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup( IHostingEnvironment env)
        {
            _env = env;

            //Para la carga del fichero de configuracion config.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath) //Donde esta el fichero
                .AddJsonFile("config.json");

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddIdentity<WindlogUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
            }).AddEntityFrameworkStores<WindlogContext>();//Añade identity al context, ya que es donde se almacenará.

            services.AddDbContext<WindlogContext>();
            services.AddScoped<IWindlogRepository, WindlogRepository>();
            services.AddTransient<WindlogContextSeedData>();
            services.AddMvc(config =>
            {
                if (_env.IsProduction())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            WindlogContextSeedData seeder)
        {
            ConfigureMappers();

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentity();            
            app.UseMvc(config =>
            {//Para que haga uso de MVC y así valla a index.cshtml
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" } //Página de inicio por defecto
                    );
            });

            seeder.SeedData().Wait();
         }

        private void ConfigureMappers()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new MaterialTypeMapper());
                config.AddProfile(new MaterialMapper());
                config.AddProfile(new SpotMapper());
            });            
        }
    }
}
