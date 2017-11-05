using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;

namespace WebApiNetCore.Repository
{
    //Esta clase vendría a simular Datos en la BDD correspondientes a la entity Persona
    public class PersonaRepository
    {
        private List<Persona> personas;

        private static PersonaRepository personaRepository = new PersonaRepository();

        private PersonaRepository() {
            personas = new List<Persona>();
            mock();
        }

        private void mock() {
            personas.Add(new Persona() { Rut = 186666364, Nombre = "Ignacio" });
            personas.Add(new Persona() { Rut = 298374895, Nombre = "Luis" });
            personas.Add(new Persona() { Rut = 98783562, Nombre = "Laura" });
        }
        public List<Persona> HttpGet() => personas;

        public void HttpDelete(int rut) => personas.Remove(personas.First(i => i.Rut == rut));

        public void HttpPost(Persona persona) => personas.Add(persona);

        public void HttpPut(int rut, PersonaModel personaModel)=>personas.First(i => i.Rut == rut).Nombre = personaModel.Nombre;

        public static PersonaRepository getInstance() {
            return personaRepository;
        }

    }
}
