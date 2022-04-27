using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;

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
    public virtual async Task<IEnumerable<TGetDto>> GetAsync()
    {
        var models = await Repository.Get();
        return Mapper.Map<IEnumerable<TGetDto>>(models);
    }

    public async Task<TGetDto> GetByIdAsync(int id)
    {
        var model = await Repository.GetById(id);
        return Mapper.Map<TGetDto>(model);
    }

    public virtual async Task<IEnumerable<TGetDto>> CreateAsync(params TCreateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Create(models);

        return Mapper.Map<IEnumerable<TGetDto>>(models);
    }

    public virtual async Task<IEnumerable<TGetDto>> UpdateAsync(params TUpdateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Update(models);

        return Mapper.Map<IEnumerable<TGetDto>>(models);
    }

    public virtual async Task RemoveAsync(params int[] ids)
    {
        var models = await Repository.GetQuery().Where(x => ids.Contains(x.Id)).ToArrayAsync();
        await Repository.Remove(models);
    }
}