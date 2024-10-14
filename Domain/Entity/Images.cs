using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Domain.Entity
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string? ImageName { get; set; }
        public byte[]? Image { get; set; }
    }
}
