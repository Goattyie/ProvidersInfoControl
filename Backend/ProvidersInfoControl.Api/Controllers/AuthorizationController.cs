using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;

namespace ProvidersInfoControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : BaseController
{
    private readonly IAuthorizationService _service;

    public AuthorizationController(IAuthorizationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] AuthCreateDto createDto) => Ok(await _service.SignIn(createDto));
}