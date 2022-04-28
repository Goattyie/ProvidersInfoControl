using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Api.Core.Attributes;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Enums;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Api.Controllers;

public abstract class AbstractController<TCreateDto, TUpdateDto, TGetDto> : BaseController
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
    public virtual async Task<IActionResult> Get() => GetResponse(await Service.GetAsync());

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id) => GetResponse(await Service.GetByIdAsync(id));
    
    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TCreateDto dto) => GetResponse(await Service.CreateAsync(dto));

    [HttpPut]
    public virtual async Task<IActionResult> Put([FromBody] TUpdateDto dto) => GetResponse(await Service.UpdateAsync(dto));

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id) => GetResponse(await Service.RemoveAsync(id));
}
