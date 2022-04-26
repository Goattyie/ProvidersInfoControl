using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Dal.Interfaces;

public interface IRepository<TModel> where TModel : BaseModel
{
    public Task<IEnumerable<TModel>> Get();
    public Task<TModel> GetById(int id);
    public Task Create(params TModel[] models);
    public Task Update(params TModel[] models);
    public Task Remove(params TModel[] models);
    public IQueryable<TModel> GetQuery();
}