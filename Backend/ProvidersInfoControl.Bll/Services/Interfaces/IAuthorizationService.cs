using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services.Interfaces;

public interface IAuthorizationService
{
    public Task<IOperationResult> SignIn(AuthCreateDto createDto);
}