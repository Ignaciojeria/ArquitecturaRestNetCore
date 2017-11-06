using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.IService;
using WebApiNetCore.Entity;
using Microsoft.AspNetCore.Authorization;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaService personaService;

        public PersonaController(IPersonaService personaService) {
            this.personaService = personaService;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<Persona> Get()
        {
            return personaService.HttpGet();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id+"";
        }

        // POST api/values
        [HttpPost]
        public Persona Post([FromBody]Persona persona)
        {
            return persona;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
