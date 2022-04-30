using AutoMapper;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Bll.Services;

public class ServiceService : AbstractService<ServiceCreateDto, ServiceUpdateDto, ServiceGetDto, Service>, IServiceService
{
    public ServiceService(IMapper mapper, IServiceRepository repository) : base(mapper, repository)
    {
    }
}