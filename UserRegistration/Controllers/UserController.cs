using Domain.Dto;
using Domain.Enum;
using Domain.Iqueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Api.Commons;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Dto;

namespace UserRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        private readonly IMediator mediator;

        public UserController(IUser user, IMediator mediator)
        {
            this.user = user;
            this.mediator = mediator;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetAll([FromQuery] PaginatedList paginationList)
        {
            var users = user.getall().ToList();
            if (!string.IsNullOrWhiteSpace(paginationList.Search))
            {
                users = users.Where(u =>
                    u.FirstName.Contains(paginationList.Search, StringComparison.OrdinalIgnoreCase) ||
                u.LastName.Contains(paginationList.Search, StringComparison.OrdinalIgnoreCase) ||

                u.UserName.Contains(paginationList.Search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }



            paginationList.TotalCount = users.Count;

            // Calculate total pages
            paginationList.TotalPage = (int)Math.Ceiling((double)paginationList.TotalCount / paginationList.PageSize);

            // Apply pagination using Skip and Take
            var paginatedResult = users
                .Skip((paginationList.CurrentPage - 1) * paginationList.PageSize)
                .Take(paginationList.PageSize)
                .ToList();

            // Return the paginated result along with pagination details
            return Ok(new
            {
                Data = paginatedResult,
                paginationList.CurrentPage,
                paginationList.TotalPage,
                paginationList.PageSize,
                paginationList.TotalCount
            });
        }

        [HttpGet("id")]
        public IActionResult getbyid(int id)
        {
            var n2 = user.getByid(id);
            if (n2 == null)
            {
                return NotFound();
            }
            return Ok(n2);
        }
        [HttpPost]
        public async Task<IActionResult> createA(UserDto2 userDto2)
        {
            var n2 = new UserCommand(Operations.create, userDto2);
            var n3 = await mediator.Send(n2);
            return Ok(n3);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAr(int id, UserDto userDto)
        {
            if (id != userDto.User_id)
            {
                return BadRequest();
            }
            var n2 = new UserCommand(Operations.update, userDto);
            var n3 = await mediator.Send(n2);
            return Ok(n3);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deltear(int id)
        {
            var n2 = new UserDto { User_id = id };
            var n3 = new UserCommand(Operations.delete, n2);
            var n4 = await mediator.Send(n3);
            return Ok(new { message = "The Content is not available" });

        }
    }
}
