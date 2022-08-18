using Repository.Entities;

namespace Business.Interfaces
{
    public interface IClientServices
    {
        void CreatClient(Client client);
        void EditCLientByID(int id, string name, int age, string message);
        List<ClientHistory> GetActionHistory();
        List<Client> GetAllClients();
        Client GetClientByID(int id);
        void RemoveCLient(int id);
    }
}