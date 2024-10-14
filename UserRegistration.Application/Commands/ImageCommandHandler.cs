using AutoMapper;
using Domain.Enum;
using Domain.Irepository;
using MediatR;
using UserRegistration.Domain.Dto;
using UserRegistration.Domain.Entity;


namespace UserRegistration.Application.Commands
{
    internal class ImageCommandHandler : IRequestHandler<ImageCommand, ImageDto>
    {
        private readonly IMapper mapper;
        private readonly IRepbase repbase;

        public ImageCommandHandler(IMapper mapper, IRepbase repbase)
        {
            this.mapper = mapper;
            this.repbase = repbase;
        }

        public async Task<ImageDto> Handle(ImageCommand request, CancellationToken cancellationToken)
        {
            //    if (request.ImageDto.file == null || request.ImageDto.file.Length == 0)
            //        throw new ArgumentException("No file provided.");

            //    var uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            //    var fileName = Path.GetFileName(request.File.FileName);
            //    var filePath = Path.Combine(uploadsFolderPath, fileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await request.File.CopyToAsync(fileStream);
            //    }

            //return filePath;
            switch (request.Operations)
            {
                case Operations.create:
                    var img1 = new Images
                    {
                        Image = request.ImageDto2.Image

                    };
                    var n2 = await repbase.CreateImage(img1);
                    return mapper.Map<ImageDto>(n2);
                case Operations.update:
                    var img2 = new Images
                    {
                        ImageId = request.ImageDto.ImageId,
                        Image = request.ImageDto.Image

                    };
                    await repbase.updateImg(request.ImageDto.ImageId, img2);
                    return mapper.Map<ImageDto>(img2);
                case Operations.delete:
                    await repbase.DeleteImg(request.ImageDto.ImageId);
                    return null;
                default:
                    throw new ArgumentException();

            }

        }
    }


}