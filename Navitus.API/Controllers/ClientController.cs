using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace Navitus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices clientService;
        private readonly IConfiguration configuration;

        public ClientController(IClientServices clientService, IConfiguration configuration)
        {
            this.clientService = clientService;
            this.configuration = configuration;
        }

        [HttpPost("Create")]
        public void Create([FromBody] Client client)
        {
            clientService.CreatClient(client.Name, client.Age, client.Message);
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
        public void EditClient([FromBody] Client client)
        {
            clientService.EditCLientByID(client.Id, client.Name, client.Age, client.Message);
        }

        [HttpPost("Delete")]
        public void Delete(int id)
        {
            clientService.RemoveCLient(id);
        }

        [HttpGet("GetHistory")]
        public List<ClientHistory> GetHistory(int id)
        {
            var result = clientService.GetActionHistory(id);
            return result;
        }
    }
}
