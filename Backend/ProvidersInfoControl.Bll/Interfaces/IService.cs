using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;

namespace ProvidersInfoControl.Bll.Interfaces;

public interface IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    public Task<IEnumerable<TGetDto>> GetAsync();
    public Task<TGetDto> GetByIdAsync(int id);
    public Task<IEnumerable<TGetDto>> CreateAsync(params TCreateDto[] dtos);
    public Task<IEnumerable<TGetDto>> UpdateAsync(params TUpdateDto[] dtos);
    public Task RemoveAsync(params int[] ids);
}