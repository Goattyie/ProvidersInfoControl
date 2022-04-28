using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class AbonentRepository : AbstractRepository<Abonent>, IAbonentRepository
{
    public AbonentRepository(PicDbContext dbContext) : base(dbContext) { }
    public override async Task<IEnumerable<Abonent>> Get() => await DataSet.Include(x => x.AbonentType).AsNoTracking().ToListAsync();

    public override async Task<Abonent> GetById(int id) =>
        await DataSet.Include(x => x.AbonentType).FirstOrDefaultAsync(x => x.Id == id);
    
}