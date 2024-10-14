using Domain.Entity;
using Domain.Irepository;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Entity;
using UserRegistration.infrastucture.Data;

namespace UserRegistration.infrastucture.Repository
{
    public class Rep : IRepbase
    {
        private readonly UserRegistation_Dbcontext userRegistation_Dbcontext;

        public Rep(UserRegistation_Dbcontext userRegistation_Dbcontext)
        {
            this.userRegistation_Dbcontext = userRegistation_Dbcontext;
        }

        public async Task<Images> CreateImage(Images images)
        {
            await userRegistation_Dbcontext.images.AddAsync(images);
            await userRegistation_Dbcontext.SaveChangesAsync();
            return images;
        }

        public async Task<Rolecs> createRoles(Rolecs rolecs)
        {
            await userRegistation_Dbcontext.rolecs.AddAsync(rolecs);
            await userRegistation_Dbcontext.SaveChangesAsync();
            return rolecs;
        }

        public async Task<User> createUser(User user)
        {
            await userRegistation_Dbcontext.users.AddAsync(user);
            await userRegistation_Dbcontext.SaveChangesAsync();
            return user;
        }

        public Task<int> DeleteImg(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> deletRoles(int id)
        {
            return await userRegistation_Dbcontext.rolecs.
                 Where(x => x.role_id == id).
                 ExecuteDeleteAsync();
        }

        public async Task<int> deletuser(int id)
        {
            return await userRegistation_Dbcontext.users.
                 Where(x => x.role_id == id).
                 ExecuteDeleteAsync();
        }

        public Task<int> updateImg(int id, Images images)
        {
            throw new NotImplementedException();
        }

        public async Task<int> updateRoles(int id, Rolecs rolecs)
        {
            return await userRegistation_Dbcontext.rolecs
                 .Where(x => x.role_id == id)
                 .ExecuteUpdateAsync(s => s.SetProperty
                 (c => c.Role, rolecs.Role));
        }

        public async Task<int> updateuser(int id, User user)
        {
            return await userRegistation_Dbcontext.users
                .Where(x => x.role_id == id)
                .ExecuteUpdateAsync(s => s.SetProperty
                (c => c.UserName, user.UserName)
                .SetProperty(c => c.FirstName, user.FirstName)
                .SetProperty(c => c.LastName, user.LastName)
                .SetProperty(c => c.password, user.password)
                .SetProperty(c => c.status, user.status)

                .SetProperty(c => c.Image, user.Image)
                .SetProperty(c => c.CreationTime, user.CreationTime)
                .SetProperty(c => c.role_id, user.role_id)
                .SetProperty(c => c.Gender, user.Gender)
                );

        }
    }
}
