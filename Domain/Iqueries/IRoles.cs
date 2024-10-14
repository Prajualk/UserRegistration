using Domain.Dto;

namespace Domain.Iqueries
{
    public interface IRoles
    {
        public IList<RolesDto> getall();
        RolesDto getbyid(int id);
    }
}
