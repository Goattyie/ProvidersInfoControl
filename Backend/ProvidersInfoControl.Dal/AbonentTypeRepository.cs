using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class AbonentTypeRepository : AbstractRepository<AbonentType>, IAbonentTypeRepository
{
    public AbonentTypeRepository(PicDbContext dbContext) : base(dbContext) { }
}