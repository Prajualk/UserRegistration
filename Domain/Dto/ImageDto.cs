using Microsoft.AspNetCore.Http;

namespace UserRegistration.Domain.Dto
{
    public class ImageDto
    {
        public int ImageId { get; set; }

        public byte[]? Image { get; set; }
        public IFormFile? file { get; set; }

    }
}
