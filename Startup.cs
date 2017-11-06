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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiNetCore.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            //Configurando autenticación 
            services.Configure<JwtConfiguration>(jwtConfig => {
                jwtConfig.Issuer = Configuration.GetSection("JWT:Issuer").Value;
                jwtConfig.Secret = Configuration.GetSection("JWT:Secret").Value;

            });

            services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(ConfigureJwtBearer);
            //Agregando nuestros servicios de autenticación como transientes!
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            //Fin Autenticación

            /* Acá deberíamos agregar nuestro dbContext pero cómo en este caso en particular estamos 
             * trabajando con información en memoria entonces no registraremos nuestro dbContext.
             
             * Ejemplo de registro del dbContext: 
             
            services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
             
            */
            services.AddSingleton<IPersonaService, PersonaService>();
            services.AddSingleton<IUserService, UserService>();

            services.AddMvc();
            //services.AddMvcCore().AddJsonFormatters();
            /* Agregamos nuestros repositorios que en producción deberían ser Scopes pero nosotros trabajaremos 
             * con Singletons para hacer pruebas de persistencia a una lista registrada en memoria. 

             * Ejemplo de nuestro servicio registrado como un Scope:
             
               services.AddScoped<IPersonaService, PersonaService>();
             */
             //Estos Servicios Registrados en el inyector de dependencias se Inyectarán en los controladores!

        }

        //Inicio  de metodos y variables para autenticación
        bool _isDevelopment;

        private void ConfigureJwtBearer(JwtBearerOptions config)
        {
            if (_isDevelopment)
                config.RequireHttpsMetadata = false;
            //Obtenemos una sección del archivo de configuración appsettings.json
              var issuer = Configuration.GetSection("JWT:Issuer").Value;
             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:Secret").Value));
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                IssuerSigningKey = key,
                ValidateAudience = false,
            };
        }//Fin de Inicio  de metodos y variables para autenticación


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _isDevelopment = true;
                app.UseDeveloperExceptionPage();
            }

            //Acá agregaremos nuevos elementos.

            // app.elementoA

            // app.elementoB

            app.UseAuthentication();

            /*Este servicio va a ser el que va a procesar la request en último momento.
            Si queremos agregar algo más lo añadiremos por encima.*/
            app.UseMvc();
        }
    }
}
