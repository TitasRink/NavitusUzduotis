using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace Navitus.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices clientService;

        [HttpPost]
        public void Create(string name, int age, string message)
        {
            clientService.CreatClient(name, age, message);
        }

        [HttpPost]
        public ActionResult GetAllClients()
        {
            var result = clientService.GetAllClients();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetCLient(int id)
        {
            var result = clientService.GetClientByID(id);
            return Ok(result);
        }

        [HttpPost]
        public void EditClient(int id, [FromBody] Client client)
        {
            clientService.EditCLientByID(id, client.Name, client.Age, client.Message);
        }

        [HttpPost]
        public void Delete(int id)
        {
            clientService.RemoveCLient(id);
        }
    }
}
