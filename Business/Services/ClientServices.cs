using Business.Interfaces;
using Repository.Entities;
using Repository.SqlDB;
using System.Text.Json;

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
            string time = $"Registered {DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}";
            Con.Clients.Add(new(name,age,message));
            Con.SaveChanges();
            var res = Con.Clients.Where(x => x.Name == name && x.Age == age).FirstOrDefault().Id;
            var log = new ClientHistory(res, time);
            var jsonString = JsonSerializer.Serialize(log);
            log.Log = jsonString;
            Con.ClientHistory.Add(log);
            Con.SaveChanges();
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
            string time = $"LastUpdated {DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}";
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
                    var log = new ClientHistory(id, time);
                    var jsonString = JsonSerializer.Serialize(log);
                    log.Log = jsonString;
                    Con.ClientHistory.Add(log);
                    Con.SaveChanges();
                }
            }
        }

        public void RemoveCLient(int id)
        {
            string time = $"LastUpdated {DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}";

            if (id == null)
            {
                return;
            }
            else
            {
                var result = Con.Clients.Where(x => x.Id == id).FirstOrDefault();
                var log = new ClientHistory(result.Id, time);
                var jsonString = JsonSerializer.Serialize(log);
                log.Log = jsonString;
                Con.ClientHistory.Add(log);
                Con.Clients.Remove(result);
                Con.SaveChanges();
            }
        }

        public List<ClientHistory> GetActionHistory(int id)
        {
            var result = Con.ClientHistory.Where(x=>x.ClientId == id).ToList();
            return result;
        }
    }
}

