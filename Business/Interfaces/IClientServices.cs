using Repository.Entities;

namespace Business.Interfaces
{
    public interface IClientServices
    {
        void CreatClient(string name, int age, string message);
        void EditCLientByID(int id, string name, int age, string message);
        List<Client> GetAllClients();
        Client GetClientByID(int id);
        void RemoveCLient(int id);
        List<ClientHistory> GetActionHistory(int id);
    }
}