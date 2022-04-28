using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services.Interfaces;

public interface IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    public Task<IOperationResult> GetAsync();
    public Task<IOperationResult> GetByIdAsync(int id);
    public Task<IOperationResult> CreateAsync(params TCreateDto[] dtos);
    public Task<IOperationResult> UpdateAsync(params TUpdateDto[] dtos);
    public Task<IOperationResult> RemoveAsync(params int[] ids);
}