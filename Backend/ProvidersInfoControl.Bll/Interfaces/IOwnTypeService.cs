using ProvidersInfoControl.Domain.Dtos.CreateDto;
using ProvidersInfoControl.Domain.Dtos.GetDto;
using ProvidersInfoControl.Domain.Dtos.UpdateDto;

namespace ProvidersInfoControl.Bll.Interfaces;

public interface IOwnTypeService : IService<OwnTypeCreateDto, OwnTypeUpdateDto, OwnTypeGetDto>
{
    
}