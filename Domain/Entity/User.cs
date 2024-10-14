using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public DateTime? CreationTime { get; set; }
        public string? Location { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public bool? status { get; set; }
        public int? role_id { get; set; }
        [ForeignKey("role_id")]
        public Rolecs? rolecs { get; set; }


    }
}
