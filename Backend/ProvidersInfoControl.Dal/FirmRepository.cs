using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class FirmRepository : AbstractRepository<Firm>, IFirmRepository
{
    public FirmRepository(PicDbContext dbContext) : base(dbContext) { }

    public override async Task<IEnumerable<Firm>> Get() => await DataSet.Include(x => x.OwnType).AsNoTracking().ToListAsync();
    public override async Task<Firm> GetById(int id) => await DataSet.Include(x => x.OwnType).FirstOrDefaultAsync(x => x.Id == id);
}