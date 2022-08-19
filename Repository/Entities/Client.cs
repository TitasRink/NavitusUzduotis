using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }

        public Client(string name, int age, string message)
        {
            Name = name;
            Age = age;
            Message = message;
        }
    }
}
