using AutoMapper;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Tools.MappingConfiguration;

public class DtoModelProfile : Profile
{
    public DtoModelProfile()
    {
        #region OwnType

        CreateMap<OwnTypeCreateDto, OwnType>();
        CreateMap<OwnTypeUpdateDto, OwnType>();
        CreateMap<OwnType, OwnTypeGetDto>();

        #endregion

        #region AbonentType

        CreateMap<AbonentTypeCreateDto, AbonentType>();
        CreateMap<AbonentTypeUpdateDto, AbonentType>();
        CreateMap<AbonentType, AbonentTypeGetDto>();

        #endregion
    }
}