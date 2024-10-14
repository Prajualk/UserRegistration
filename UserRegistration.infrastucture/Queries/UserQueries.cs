using AutoMapper;
using Domain.Dto;
using Domain.Iqueries;
using UserRegistration.infrastucture.Data;

namespace UserRegistration.infrastucture.Queries
{
    public class UserQueries : IUser
    {
        private readonly UserRegistation_Dbcontext userRegistation_Dbcontext;
        private readonly IMapper mapper;

        public UserQueries(UserRegistation_Dbcontext userRegistation_Dbcontext, IMapper mapper)
        {
            this.userRegistation_Dbcontext = userRegistation_Dbcontext;
            this.mapper = mapper;
        }



        public IList<UserDto> getall()
        {
            var n2 = userRegistation_Dbcontext.users.ToList();


            return mapper.Map<IList<UserDto>>(n2);



        }


        public UserDto getByid(int id)
        {
            var n3 = userRegistation_Dbcontext.users.FirstOrDefault(x => x.role_id == id);
            return mapper.Map<UserDto>(n3);
        }
    }
}
