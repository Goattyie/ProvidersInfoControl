using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;

namespace ProvidersInfoControl.Bll.Services.Interfaces;

public interface IAuthorizationService
{
    public Task<AuthGetDto> SignIn(AuthCreateDto createDto);
}