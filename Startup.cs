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
using WebApiNetCore.ServiceImpl;
using WebApiNetCore.IService;

namespace WebApiNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // En este método vamos a configurar las dependencias de nuestra web api!!
        //Referencia: https://stackoverflow.com/questions/41058142/injecting-dbcontext-into-service-layer
        public void ConfigureServices(IServiceCollection services)
        {

            /* Acá deberíamos agregar nuestro dbContext pero cómo en este caso en particular estamos 
             * trabajando con información en memoria entonces no registraremos nuestro dbContext.
             
             * Ejemplo de registro del dbContext: 
             
            services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
             
            */

               services.AddMvc();
            //services.AddMvcCore().AddJsonFormatters();
            /* Agregamos nuestros repositorios que en producción deberían ser Scopes pero nosotros trabajaremos 
             * con Singletons para hacer pruebas de persistencia a una lista registrada en memoria. 

             * Ejemplo de nuestro servicio registrado como un Scope:
             
               services.AddScoped<IPersonaService, PersonaService>();
             */
             //Estos Servicios Registrados en el inyector de dependencias se Inyectarán en los controladores!
            services.AddSingleton<IPersonaService, PersonaService>();
            services.AddSingleton<IUserService,UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Acá agregaremos nuevos elementos.
            
            // app.elementoA
            
            // app.elementoB

            /*Este servicio va a ser el que va a procesar la request en último momento.
            Si queremos agregar algo más lo añadiremos por encima.*/
            app.UseMvc();
        }
    }
}
