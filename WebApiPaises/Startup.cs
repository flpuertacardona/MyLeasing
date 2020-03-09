using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiPaises.Models;

namespace WebApiPaises
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("paisDB"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            if (!context.Paises.Any())
            {

                context.Paises.AddRange(new List<Pais>()
                {
                    new Pais() { Nombre = "Colombia"},
                    new Pais() { Nombre = "Ecuador" },
                    new Pais() { Nombre = "Brazil" },
                    new Pais() { Nombre = "Venezuela" },
                    new Pais() { Nombre = "Bolivia" },
                    new Pais() { Nombre = "Peru" },
                    new Pais() { Nombre = "Argentina" }
                });
            }
            
            if (!context.Provincias.Any())
            {
                context.Provincias.AddRange(new List<Provincia>()
                {
                    new Provincia() { Nombre = "Antioquia", PaisId=1},
                    new Provincia() { Nombre = "Santander", PaisId=1},
                    new Provincia() { Nombre = "Amazonas", PaisId=1},
                    new Provincia() { Nombre = "Atlantico", PaisId=1},
                    new Provincia() { Nombre = "Brazil Antioquia", PaisId=3},
                    new Provincia() { Nombre = "Brazil Santander", PaisId=3},
                    new Provincia() { Nombre = "Brazil Amazonas", PaisId=3},
                    new Provincia() { Nombre = "Brazil Atlantico", PaisId=3},
                    new Provincia() { Nombre = "Bolivia Antioquia", PaisId=5},
                    new Provincia() { Nombre = "Bolivia Santander", PaisId=5},
                    new Provincia() { Nombre = "Bolivia Amazonas", PaisId=5},
                    new Provincia() { Nombre = "Bolivia Atlantico", PaisId=5},
                    new Provincia() { Nombre = "Peru Antioquia", PaisId=6},
                    new Provincia() { Nombre = "Peru Santander", PaisId=6},
                    new Provincia() { Nombre = "Peru Amazonas", PaisId=6},
                    new Provincia() { Nombre = "Peru Atlantico", PaisId=6},
                    new Provincia() { Nombre = "Argentina Antioquia", PaisId=7},
                    new Provincia() { Nombre = "Argentina Santander", PaisId=7},
                    new Provincia() { Nombre = "Argentina Amazonas", PaisId=7},
                    new Provincia() { Nombre = "Argentina Atlantico", PaisId=7}
                });

                context.SaveChanges();
            }
        }
    }
}
