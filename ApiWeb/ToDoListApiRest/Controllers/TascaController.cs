using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoListApiRest.DAL.Service;
using ToDoListApiRest.DAL.Model;
using MongoDB.Bson;

namespace ToDoListApiRest.Controllers
{
    [Route("api/tasques")]
    [ApiController]
    public class TascaController : ControllerBase
    {
        // GET: users
        [HttpGet]
        public List<Tasca> Get()
        {
            UserService objUserService = new UserService();
            return objUserService.GetAll();//Aqui hem de passar un array o algo que contingui les 3 llistes de tasques
        }

        // GET users/5
        [HttpGet("{estat}")]
        public List<Tasca> Get(int estat)
        {
            UserService objUserService = new UserService();
            return objUserService.Select(estat);
        }

        /*// GET users/5
        [HttpGet("{id}")]
        public List<Tasca> Get(ObjectId Id)
        {
            UserService objUserService = new UserService();
            return objUserService.Select(Id);
        }*/

        // POST users
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            UserService objUserService = new UserService();
            objUserService.Add(tasca);
        }

        // PUT users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tasca tasca)
        {
            UserService objUserService = new UserService();
            objUserService.Update(tasca);
        }

        // DELETE users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserService objUserService = new UserService();
            objUserService.Delete(id);
        }
    }
    
}
