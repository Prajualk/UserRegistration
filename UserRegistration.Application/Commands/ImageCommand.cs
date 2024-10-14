using Domain.Enum;
using MediatR;
using UserRegistration.Domain.Dto;

namespace UserRegistration.Application.Commands
{
    public class ImageCommand : IRequest<ImageDto>
    {


        public ImageCommand(Operations operations, ImageDto imageDto)
        {
            Operations = operations;
            ImageDto = imageDto;
        }
        public ImageCommand(Operations operations, ImageDto2 imageDto2)
        {
            ImageDto2 = imageDto2;
        }

        public Operations Operations { get; }
        public ImageDto ImageDto { get; }
        public ImageDto2 ImageDto2 { get; }
    }
}
