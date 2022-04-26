using AutoMapper;
using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;
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
    }
}