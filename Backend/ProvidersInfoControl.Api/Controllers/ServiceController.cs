using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;

namespace ProvidersInfoControl.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ServiceController : AbstractController<ServiceCreateDto, ServiceUpdateDto, ServiceGetDto>
{
    public ServiceController(IServiceService service) : base(service)
    {
    }
}