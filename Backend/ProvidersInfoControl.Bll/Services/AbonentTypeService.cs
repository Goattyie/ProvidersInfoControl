using AutoMapper;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Bll.Services;

public class AbonentTypeService : AbstractService<AbonentTypeCreateDto, AbonentTypeUpdateDto, AbonentTypeGetDto, AbonentType>, IAbonentTypeService
{
    public AbonentTypeService(IMapper mapper, IAbonentTypeRepository repository) : base(mapper, repository) { }
}