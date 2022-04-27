using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Api.Core.Attributes;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Enums;

namespace ProvidersInfoControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbonentTypeController : AbstractController<AbonentTypeCreateDto, AbonentTypeUpdateDto, AbonentTypeGetDto>
{
    public AbonentTypeController(IAbonentTypeService service) : base(service) { }
}