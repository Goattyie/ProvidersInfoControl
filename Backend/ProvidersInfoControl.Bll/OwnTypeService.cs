using AutoMapper;
using ProvidersInfoControl.Bll.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Bll;

public class OwnTypeService : AbstractService<OwnTypeCreateDto, OwnTypeUpdateDto, OwnTypeGetDto, OwnType>, IOwnTypeService
{
    public OwnTypeService(IMapper mapper, IOwnTypeRepository repository) : base(mapper, repository) { }
}