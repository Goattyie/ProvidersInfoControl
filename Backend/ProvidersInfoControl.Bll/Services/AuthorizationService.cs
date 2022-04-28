using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using ProvidersInfoControl.Bll.Localization;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Bll.Utils;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _repository;

    public AuthorizationService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IOperationResult> SignIn(AuthCreateDto dto)
    {
        var user = _repository.GetQuery().FirstOrDefault(x => x.Login == dto.Login);

        if (user is null)
            return Task.FromResult(OperationResult.Bad(Errors.WrongLogin));


        var hashBytes = Convert.FromBase64String(user.Password);
        var salt = new byte[16];

        Array.Copy(hashBytes, 0, salt, 0, 16);

        var pbkdf2 = new Rfc2898DeriveBytes(dto.Password, salt, 100000);
        var hash = pbkdf2.GetBytes(20);

        for (int i = 0; i < 20; i++)
        {
            if (hashBytes[i + 16] != hash[i])
                return Task.FromResult(OperationResult.Bad(Errors.WrongPassword));
        }

        var claims = new List<Claim>()
        {
            new Claim("login", user.Login),
            new Claim("role", user.Role.ToString())
        };
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: DateTime.UtcNow,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        
        var getDto = new AuthGetDto()
        {
            Login = user.Login,
            Token = encodedJwt
        };
        
        return Task.FromResult(OperationResult.Ok(getDto));
    }
}