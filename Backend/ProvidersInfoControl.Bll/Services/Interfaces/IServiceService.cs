using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;

namespace ProvidersInfoControl.Bll.Services.Interfaces;

public interface IServiceService : IService<ServiceCreateDto, ServiceUpdateDto, ServiceGetDto>
{
    
}