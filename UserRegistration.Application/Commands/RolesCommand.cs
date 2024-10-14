using Domain.Dto;
using Domain.Enum;
using MediatR;
using UserRegistration.Domain.Dto;

namespace UserRegistration.Application.Commands
{
    public class RolesCommand : IRequest<RolesDto>
    {
        public RolesCommand(Operations operations, RolesDto rolesDto)
        {
            Operations = operations;
            RolesDto = rolesDto;
        }
        public RolesCommand(Operations operations, RoleDto2 roleDto2)
        {
            Operations = operations;
            RoleDto2 = roleDto2;
        }

        public Operations Operations { get; }
        public RoleDto2 RoleDto2 { get; }
        public RolesDto RolesDto { get; }
    }
}
