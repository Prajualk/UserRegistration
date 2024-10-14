using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Rolecs
    {
        [Key]
        public int role_id { get; set; }
        public string? Role { get; set; }
    }
}
