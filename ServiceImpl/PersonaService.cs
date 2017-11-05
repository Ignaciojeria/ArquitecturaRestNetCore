using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.IService;
using WebApiNetCore.Model;
using WebApiNetCore.Repository;

namespace WebApiNetCore.ServiceImpl
{
    //Los Servicios debemos registrarlos en el inyector de dependencias de .NetCore en la clase StartUp.cs
    public class PersonaService : IPersonaService
    {
        /*El registro del dbContext debería ser así!!* Referencia: https://stackoverflow.com/questions/41058142/injecting-dbcontext-into-service-layer
    
    *Inyectando la dependencia:
    private readonly DbContext _context;
    public MyService(DbContext ctx){
         _context = ctx;
    }

    *Usando la dependencia inyectada dentro de los métodos Implementados por IPersonaService

    public Persona GetPersona(int rut){
        var personas = from u in _context.Persona where u.rut == rut select u;
        if (users.Count() == 1)
        {
            return users.First();
        }
        return null;
    }
         */

        /*En este caso en particular vamos a utilizar retornar un singleton proveniente de nuestro DbContext.
         * (No Inyectaremos ninguna dependencia! pero en producción
            deberíamos utilizar la inyección de dependencias!!!).*/
        PersonaRepository personaRepository = PDbContext.GetPersonaRepositoryFromDbContext();


        public void HttpDelete(int rut)
        {
            personaRepository.HttpDelete(rut);
        }

        public List<Persona> HttpGet()
        {
          return  personaRepository.HttpGet();
        }

        public void HttpPost(Persona persona)
        {
            personaRepository.HttpPost(persona);
        }

        public void HttpPut(int rut, PersonaModel personaModel)
        {
            personaRepository.HttpPut(rut,personaModel);
        }
    }
}
