using AutoMapper;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Bll.Services;

public class OwnTypeService : AbstractService<OwnTypeCreateDto, OwnTypeUpdateDto, OwnTypeGetDto, OwnType>, IOwnTypeService
{
    public OwnTypeService(IMapper mapper, IOwnTypeRepository repository) : base(mapper, repository) { }
}