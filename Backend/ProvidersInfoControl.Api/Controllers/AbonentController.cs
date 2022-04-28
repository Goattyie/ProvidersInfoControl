using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;

namespace ProvidersInfoControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Abonent : AbstractController<AbonentCreateDto, AbonentUpdateDto, AbonentGetDto>
{
    public Abonent(IAbonentService service) : base(service) { }
}