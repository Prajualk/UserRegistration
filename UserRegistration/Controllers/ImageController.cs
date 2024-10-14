using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Domain.Entity;
using UserRegistration.infrastucture.Data;

namespace UserRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly UserRegistation_Dbcontext dbcontext;

        public ImageController(IMediator mediator, UserRegistation_Dbcontext dbcontext)
        {
            this.mediator = mediator;
            this.dbcontext = dbcontext;

        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file, string name)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            var image = new Images
            {
                ImageName = name,
                Image = imageBytes
            };
            dbcontext.Add(image);
            dbcontext.SaveChanges();
            return Ok(imageBytes);
        }

        [HttpPut("update/{existingFileName}")]
        public async Task<IActionResult> UpdateImage([FromRoute] string existingFileName, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }
            var existingImage = dbcontext.images.FirstOrDefault(x => x.ImageName == existingFileName);

            if (existingImage == null)
            {
                return NotFound($"Image with name '{existingFileName}' not found.");
            }

            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            existingImage.Image = imageBytes;
            existingImage.ImageName = file.FileName;
            dbcontext.images.Update(existingImage);
            await dbcontext.SaveChangesAsync();

            return Ok("Image updated successfully.");
        }
    }
}


