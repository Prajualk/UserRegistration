using Domain.Dto;

namespace Domain.Iqueries
{
    public interface IUser
    {
        IList<UserDto> getall();
        UserDto getByid(int id);

    }
}
