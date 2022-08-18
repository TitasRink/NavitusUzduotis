using Business.Interfaces;
using Repository.Entities;
using Repository.SqlDB;

namespace Business.Services
{
    public class ClientServices : IClientServices
    {
        private SqlConnection Con { get; }

        public ClientServices(SqlConnection con)
        {
            Con = con;
        }

        public void CreatClient(string name, int age, string message)
        {
            if (string.IsNullOrEmpty(name) || age == null || string.IsNullOrEmpty(message))
            {
                return;
            }
            else
            {
                Con.Clients.Add(new(name, age, message));
                Con.ClientHistory.Add(new(name));
                Con.SaveChanges();
            }
        }

        public List<Client> GetAllClients()
        {
            var result = Con.Clients.ToList();
            return result;
        }

        public Client GetClientByID(int id)
        {
            var result = Con.Clients.Where(x => x.Id == id).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public void EditCLientByID(int id, string name, int age, string message)
        {
            if (string.IsNullOrEmpty(name) || age == null || string.IsNullOrEmpty(message))
            {
                return;
            }
            else
            {
                var result = Con.Clients.Where(x => x.Id == id).FirstOrDefault();

                if (result == null)
                {
                    return;
                }
                else
                {
                    result.Age = age;
                    result.Name = name;
                    result.Message = message;
                    Con.ClientHistory.Add(new(id));
                    Con.SaveChanges();
                }
            }
        }

        public void RemoveCLient(int id)
        {
            if (id == null)
            {
                return;
            }
            else
            {
                var result = Con.Clients.Where(x => x.Id == id).FirstOrDefault();
                Con.ClientHistory.Add(new(result.Id, result.Name));
                Con.Clients.Remove(result);
                Con.SaveChanges();
            }
        }

        public List<ClientHistory> GetActionHistory()
        {
            var result = Con.ClientHistory.ToList();
            return result;
        }
    }
}

