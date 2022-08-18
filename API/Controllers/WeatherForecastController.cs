using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IClientServices clientService;

        [HttpPost("Create")]
        public void Create([FromBody]Client client)
        {
            clientService.CreatClient(client);
        }

        [HttpGet("GetAllClients")]
        public List<Client> GetAllClients()
        {
            var result = clientService.GetAllClients();
            return result;
        }

        [HttpGet("GetClientID")]
        public ActionResult GetCLient(int id)
        {
            var result = clientService.GetClientByID(id);
            return Ok(result);
        }

        [HttpPost("EditClient")]
        public void EditClient(int id, [FromBody] Client client)
        {
            clientService.EditCLientByID(id, client.Name, client.Age, client.Message);
        }

        [HttpPost("Delete")]
        public void Delete(int id)
        {
            clientService.RemoveCLient(id);
        }
    }
}