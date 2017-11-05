using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;

namespace WebApiNetCore.IService
{
    //Un crud utilizando los nombres de los métodos del Protocolo Http
    public interface IPersonaService
    {
        void HttpGet();
        void HttpPost(Persona persona);
        void HttpPut(int rut, PersonaModel personaModel);//Está un poco feo el método put! xDD
        void HttpDelete(int rut);
    }
}
