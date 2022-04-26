using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Bll.Interfaces;
using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;

namespace ProvidersInfoControl.Api.Controllers;

public abstract class AbstractController<TCreateDto, TUpdateDto, TGetDto> : ControllerBase
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    protected IService<TCreateDto, TUpdateDto, TGetDto> Service { get; }

    public AbstractController(IService<TCreateDto, TUpdateDto, TGetDto> service)
    {
        Service = service;
    }
    
    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var locationDtoList = await Service.GetAsync();

        return Ok(locationDtoList);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id)
    {
        var dto = await Service.GetByIdAsync(id);

        return Ok(dto);
    }
    
    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TCreateDto dto)
    {
        var createdDto = await Service.CreateAsync(dto);

        return Ok(createdDto.First());
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put([FromBody] TUpdateDto dto)
    {
        var updatedDto = await Service.UpdateAsync(dto);

        return Ok(updatedDto.First());
    }

    [HttpDelete]
    public virtual async Task<IActionResult> Delete(int id)
    {
        await Service.RemoveAsync(id);
        return Ok();
    }
}
