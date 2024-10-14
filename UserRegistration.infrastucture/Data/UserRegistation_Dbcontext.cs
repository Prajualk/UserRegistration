using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Entity;

namespace UserRegistration.infrastucture.Data
{
    public class UserRegistation_Dbcontext : DbContext
    {
        public UserRegistation_Dbcontext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<User> users { get; set; }
        public DbSet<Rolecs> rolecs { get; set; }
        public DbSet<Images> images { get; set; }
    }
}
