using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services;

public abstract class AbstractService<TCreateDto, TUpdateDto, TGetDto, TModel> : IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
    where TModel: BaseModel
{
    public AbstractService(IMapper mapper, IRepository<TModel> repository)
    {
        Mapper = mapper;
        Repository = repository;
    }

    protected IRepository<TModel> Repository { get; }
    protected IMapper Mapper { get; }
    public virtual async Task<IOperationResult> GetAsync()
    {
        var models = await Repository.Get();
        var dtos = Mapper.Map<IEnumerable<TGetDto>>(models);
        
        return OperationResult.Ok(dtos);
    }

    public async Task<IOperationResult> GetByIdAsync(int id)
    {
        var model = await Repository.GetById(id);
        var dtos = Mapper.Map<TGetDto>(model);
        
        return OperationResult.Ok(dtos);
    }

    public virtual async Task<IOperationResult> CreateAsync(params TCreateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Create(models);

        var getDtos = Mapper.Map<IEnumerable<TGetDto>>(models);
        
        return OperationResult.Ok(getDtos.First());

    }

    public virtual async Task<IOperationResult> UpdateAsync(params TUpdateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Update(models);

        var getDtos =  Mapper.Map<IEnumerable<TGetDto>>(models);
        
        return OperationResult.Ok(getDtos.First());
    }

    public virtual async Task<IOperationResult> RemoveAsync(params int[] ids)
    {
        var models = await Repository.GetQuery().Where(x => ids.Contains(x.Id)).ToArrayAsync();
        await Repository.Remove(models);
        
        return OperationResult.NoContent();
    }
}