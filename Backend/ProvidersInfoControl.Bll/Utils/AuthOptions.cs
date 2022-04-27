using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProvidersInfoControl.Bll.Utils;

public class AuthOptions
{
    public const string ISSUER = "PicApi";
    public const string AUDIENCE = "PicClient";
    public const int LIFETIME = 1;
    const string KEY = "PicSuperSecretKey123321OSGOATTYIE";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}