using Domain.Entity;
using UserRegistration.Domain.Entity;

namespace Domain.Irepository
{
    public interface IRepbase
    {
        Task<Rolecs> createRoles(Rolecs rolecs);
        Task<int> updateRoles(int id, Rolecs rolecs);
        Task<int> deletRoles(int id);
        Task<User> createUser(User user);
        Task<int> updateuser(int id, User user);
        Task<int> deletuser(int id);
        Task<Images> CreateImage(Images images);
        Task<int> updateImg(int id, Images images);
        Task<int> DeleteImg(int id);



    }
}
