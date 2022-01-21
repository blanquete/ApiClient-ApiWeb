using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToDoListApiRest.DAL.Service;
using ToDoListApiRest.DAL.Model;

namespace ToDoListApiRest.Controllers
{

    [Route("api/responsables")]
    [ApiController]

    public class ResponsableController : ControllerBase
    {
        // GET: responsables
        [HttpGet]
        public List<Responsable> Get()
        {
            UserService objUserService = new UserService();
            return objUserService.SelectR();
        }

        // POST responsables
        [HttpPost]
        public void Post([FromBody] Responsable responsable)
        {
            UserService objUserService = new UserService();
            objUserService.afegirResponsable(responsable);
        }

        /*// GET responsables/5
        [HttpGet("{id}")]
        public List<Responsable> Get(int id)
        {
            UserService objUserService = new UserService();
            return objUserService.Select(id);
        }

        // PUT responsables/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Responsable responsable)
        {
            UserService objUserService = new UserService();
            objUserService.Update(responsable);
        }

        // DELETE responsables/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserService objUserService = new UserService();
            objUserService.Delete(id);
        }*/

    }
}
