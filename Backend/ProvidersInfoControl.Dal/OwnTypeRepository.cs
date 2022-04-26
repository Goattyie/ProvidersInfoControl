using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class OwnTypeRepository : AbstractRepository<OwnType>, IOwnTypeRepository
{
    public OwnTypeRepository(PicDbContext dbContext) : base(dbContext) { }
}