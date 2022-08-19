using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ClientHistory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Log { get; set; }
        public int ClientId { get; set; }

        public ClientHistory()
        {
        }
        public ClientHistory(int clientID, string log)
        {
            ClientId = clientID;
            Log = log;
        }
    }
}
