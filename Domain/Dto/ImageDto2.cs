using Microsoft.AspNetCore.Http;

namespace UserRegistration.Domain.Dto
{
    public class ImageDto2
    {
        public byte[]? Image { get; set; }
        public IFormFile? file { get; set; }
    }
}
