using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToDoListApiRest.DAL.Service;
using ToDoListApiRest.DAL.Model;


namespace ToDoListApiRest.Controllers
{

    [Route("api/prioritats")]
    [ApiController]

    public class PrioritatController : ControllerBase
    {
        // GET: prioritats
        [HttpGet]
        public List<Prioritat> Get()
        {
            UserService objUserService = new UserService();
            return objUserService.SelectP();
        }

        /*// GET prioritats/5
        [HttpGet("{id}")]
        public List<Prioritat> Get(int id)
        {
            UserService objUserService = new UserService();
            return objUserService.Select(id);
        }

        // POST prioritats
        [HttpPost]
        public void Post([FromBody] Prioritat prioritat)
        {
            UserService objUserService = new UserService();
            objUserService.Add(prioritat);
        }

        // PUT prioritats/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Prioritat prioritat)
        {
            UserService objUserService = new UserService();
            objUserService.Update(prioritat);
        }

        // DELETE prioritats/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserService objUserService = new UserService();
            objUserService.Delete(id);
        }*/
        
    }
}
