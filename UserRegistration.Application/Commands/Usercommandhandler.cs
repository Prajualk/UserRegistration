using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.Enum;
using Domain.Irepository;
using MediatR;

namespace UserRegistration.Application.Commands
{
    public class Usercommandhandler : IRequestHandler<UserCommand, UserDto>
    {
        private readonly IRepbase repbase;
        private readonly IMapper mapper;

        public Usercommandhandler(IRepbase repbase, IMapper mapper)
        {
            this.repbase = repbase;
            this.mapper = mapper;
        }
        public async Task<UserDto> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            switch (request.Operations)
            {
                case Operations.create:
                    var user1 = new User
                    {
                        FirstName = request.UserDto2.FirstName,
                        LastName = request.UserDto2.LastName,
                        Location = request.UserDto2.location,
                        CreationTime = request.UserDto2.CreationTime,
                        password = request.UserDto2.password,
                        Gender = request.UserDto2.Gender,
                        Image = request.UserDto2.Image,

                        UserName = request.UserDto2.UserName
                    };
                    var n2 = await repbase.createUser(user1);
                    return mapper.Map<UserDto>(n2);
                case Operations.update:
                    var user2 = new User
                    {
                        User_id = request.UserDto.User_id,
                        UserName = request.UserDto.UserName,
                        FirstName = request.UserDto.FirstName,
                        LastName = request.UserDto.LastName,
                        Location = request.UserDto.location,
                        CreationTime = request.UserDto.CreationTime,
                        password = request.UserDto.password,
                        Gender = request.UserDto.Gender,
                        Image = request.UserDto.Image,


                    };
                    await repbase.updateuser(request.UserDto.User_id, user2);
                    return mapper.Map<UserDto>(user2);
                case Operations.delete:
                    await repbase.deletuser(request.UserDto.User_id);
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
