using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.Enum;
using Domain.Irepository;
using MediatR;

namespace UserRegistration.Application.Commands
{
    public class RoleCommandHandler : IRequestHandler<RolesCommand, RolesDto>
    {
        private readonly IRepbase repbase;
        private readonly IMapper mapper;

        public RoleCommandHandler(IRepbase repbase, IMapper mapper)
        {
            this.repbase = repbase;
            this.mapper = mapper;
        }
        public async Task<RolesDto> Handle(RolesCommand request, CancellationToken cancellationToken)
        {
            switch (request.Operations)
            {
                case Operations.create:
                    var Role1 = new Rolecs
                    {
                        Role = request.RoleDto2.Role
                    };
                    var n2 = await repbase.createRoles(Role1);
                    return mapper.Map<RolesDto>(n2);
                case Operations.update:
                    var role2 = new Rolecs
                    {
                        role_id = request.RolesDto.role_id,
                        Role = request.RolesDto.Role
                    };

                    await repbase.updateRoles(request.RolesDto.role_id, role2);
                    return mapper.Map<RolesDto>(role2);
                case Operations.delete:
                    await repbase.deletRoles(request.RolesDto.role_id);
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();


            }
        }
    }
}
