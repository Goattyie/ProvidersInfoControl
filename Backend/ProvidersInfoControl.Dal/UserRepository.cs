using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class UserRepository : AbstractRepository<User>, IUserRepository
{
    public UserRepository(PicDbContext dbContext) : base(dbContext) { }
}