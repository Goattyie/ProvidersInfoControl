using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Bll.Interfaces;
using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;

namespace ProvidersInfoControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnTypeController : AbstractController<OwnTypeCreateDto, OwnTypeUpdateDto, OwnTypeGetDto>
{
    public OwnTypeController(IOwnTypeService service) : base(service) { }
}