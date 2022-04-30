using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public class ServiceRepository : AbstractRepository<Service>, IServiceRepository
{
    public ServiceRepository(PicDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Service>> Get() => 
        await DataSet.Include(x => x.Abonent)
            .ThenInclude(x => x.AbonentType)
            .AsNoTracking()
            .ToListAsync();
}