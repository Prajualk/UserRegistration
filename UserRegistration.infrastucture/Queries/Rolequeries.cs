using AutoMapper;
using Domain.Dto;
using Domain.Iqueries;
using UserRegistration.infrastucture.Data;

namespace UserRegistration.infrastucture.Queries
{
    public class Rolequeries : IRoles
    {
        private readonly UserRegistation_Dbcontext userRegistation_Dbcontext;
        private readonly IMapper mapper;

        public Rolequeries(UserRegistation_Dbcontext userRegistation_Dbcontext, IMapper mapper)
        {
            this.userRegistation_Dbcontext = userRegistation_Dbcontext;
            this.mapper = mapper;
        }

        public IList<RolesDto> getall()
        {
            var n2 = userRegistation_Dbcontext.rolecs.ToList();
            return mapper.Map<IList<RolesDto>>(n2);
        }

        public RolesDto getbyid(int id)
        {
            var n3 = userRegistation_Dbcontext.rolecs.FirstOrDefault(x => x.role_id == id);
            return mapper.Map<RolesDto>(n3);
        }
    }
}
