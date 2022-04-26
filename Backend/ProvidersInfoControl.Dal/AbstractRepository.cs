using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal;

public abstract class AbstractRepository<TModel> : IRepository<TModel> where TModel : BaseModel
{
    protected DbSet<TModel> DataSet { get; }
    protected PicDbContext DbContext { get; }

    public AbstractRepository(PicDbContext dbContext)
    {
        DbContext = dbContext;
        DataSet = dbContext.Set<TModel>();
    }
    
    public virtual async Task<IEnumerable<TModel>> Get() => await DataSet.AsNoTracking().ToListAsync();

    public virtual async Task<TModel> GetById(int id) => await DataSet.FindAsync(id);

    public virtual async Task Create(params TModel[] models)
    {
        await DataSet.AddRangeAsync(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task Update(params TModel[] models)
    {
        DataSet.UpdateRange(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task Remove(params TModel[] models)
    {
        DataSet.RemoveRange(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual IQueryable<TModel> GetQuery() => DataSet.AsQueryable();
}