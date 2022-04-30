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

        #region Abonent

        CreateMap<AbonentCreateDto, Abonent>();
        CreateMap<AbonentUpdateDto, Abonent>();
        CreateMap<Abonent, AbonentGetDto>();

        #endregion

        #region Service

        CreateMap<ServiceCreateDto, Service>().ForMember(x => x.RecievingDate,
            opt => opt.MapFrom(d => DateOnly.Parse(d.RecievingDate)));
        CreateMap<ServiceUpdateDto, Service>().ForMember(x => x.RecievingDate,
            opt => opt.MapFrom(d => DateOnly.Parse(d.RecievingDate)));
        CreateMap<Service, ServiceGetDto>().ForMember(x => x.RecievingDate, 
            opt => 
                opt.MapFrom(s => s.RecievingDate.ToString()));

        #endregion

        #region Firm

        CreateMap<FirmCreateDto, Firm>();
        CreateMap<FirmUpdateDto, Firm>();
        CreateMap<Firm, FirmGetDto>();

        #endregion

        #region Contract

        CreateMap<ContractCreateDto, Contract>().ForMember(x => x.ConnectionDate,
            opt => opt.MapFrom(d => DateOnly.Parse(d.ConnectionDate)));
        CreateMap<ContractUpdateDto, Contract>().ForMember(x => x.ConnectionDate,
            opt => opt.MapFrom(d => DateOnly.Parse(d.ConnectionDate)));
        CreateMap<Contract, ContractGetDto>().ForMember(x => x.ConnectionDate, 
            opt => opt.MapFrom(s => s.ConnectionDate.ToString()));

        #endregion
    }
}