using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class ContractRepository : AbstractRepository<Contract>, IContractRepository
{
    public ContractRepository(PicDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Contract>> Get() =>
        await DataSet.Include(x => x.Firm)
            .ThenInclude(f => f.OwnType)
            .Include(x => x.Abonent)
            .ThenInclude(a => a.AbonentType).AsNoTracking().ToListAsync();

    public override async Task<Contract> GetById(int id) => await DataSet.Include(x => x.Firm)
        .ThenInclude(f => f.OwnType)
        .Include(x => x.Abonent)
        .ThenInclude(a => a.AbonentType)
        .FirstOrDefaultAsync(x => x.Id == id);
}