using Domain.Dto;
using Domain.Enum;
using MediatR;
using UserRegistration.Domain.Dto;

namespace UserRegistration.Application.Commands
{
    public class UserCommand : IRequest<UserDto>
    {
        public UserCommand(Operations operations, UserDto userDto)
        {
            Operations = operations;
            UserDto = userDto;
        }
        public UserCommand(Operations operations, UserDto2 userDto2)
        {
            Operations = operations;
            UserDto2 = userDto2;
        }

        public Operations Operations { get; }
        public UserDto2 UserDto2 { get; }
        public UserDto UserDto { get; }
    }
}
