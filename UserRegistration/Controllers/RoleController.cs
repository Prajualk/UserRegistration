using Domain.Dto;
using Domain.Enum;
using Domain.Iqueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Dto;

namespace UserRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoles roles;
        private readonly IMediator mediator;

        public RoleController(IRoles roles, IMediator mediator)
        {
            this.roles = roles;
            this.mediator = mediator;
        }
        [HttpGet]
        public IActionResult getall()
        {
            var n2 = roles.getall();
            return Ok(n2);
        }
        [HttpGet("id")]
        public IActionResult getbyid(int id)
        {
            var n2 = roles.getbyid(id);
            if (n2 == null)
            {
                return NotFound();
            }
            return Ok(n2);
        }
        [HttpPost]
        public async Task<IActionResult> createrole(RoleDto2 roleDto2)
        {
            var n2 = new RolesCommand(Operations.create, roleDto2);
            var n3 = await mediator.Send(n2);
            return Ok(n3);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updaterole(int id, RolesDto rolesDto)
        {
            if (id != rolesDto.role_id)
            {
                return BadRequest();
            }
            var n2 = new RolesCommand(Operations.update, rolesDto);
            var n3 = await mediator.Send(n2);
            return Ok(n3);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deltRole(int id)
        {
            var n2 = new RolesDto { role_id = id };
            var n3 = new RolesCommand(Operations.delete, n2);
            var n4 = await mediator.Send(n3);
            return Ok(new { message = "The Content is not available" });

        }
    }
}
