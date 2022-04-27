using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Api.Core.Attributes;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Enums;

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
    [RoleAttribute(UserRole.Admin, UserRole.Operator)]
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

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        await Service.RemoveAsync(id);
        return Ok();
    }
}
