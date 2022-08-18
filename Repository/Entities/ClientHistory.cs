using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ClientHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Deleted { get; set; }
        public Client _Client { get; set; }

        public ClientHistory()
        {
        }

        public ClientHistory(string name)
        {
            _Client.Name = name;
            Registered = DateTime.Now;
        }

        public ClientHistory(int id)
        {
            _Client.Id = id;
            LastUpdated = DateTime.Now;
        }

        public ClientHistory(int id, string name)
        {
            _Client.Id = id;
            _Client.Name = name;
            Deleted = DateTime.Now;
        }
    }
}
