using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore.Repository
{
    //Esto vendría a simular nuestro el db context de entity framework en este caso en particular es un singleton.
    //En producción no se crean repositorios! el DBContext provee la capa de acceso a Datos y se debe registrar en
    //Startup.cs!!
    public class PDbContext
    {
        public static PersonaRepository GetPersonaRepositoryFromDbContext() {
            return PersonaRepository.getInstance();
        }
        /* public EntityRepository EntityDbContext() {
            return EntityDbContext.getInstance();
        }*/
    }
}
