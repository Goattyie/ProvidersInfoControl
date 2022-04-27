using System.Security.Cryptography;
using ProvidersInfoControl.Domain.Enums;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.TableCreators;

public class UserCreator
{
    public static void Init(PicDbContext context)
    {
        var user1 = new User() { Login = "root", Password = HashPassword("1234"), Role = UserRole.Admin};
        var user2 = new User() { Login = "operator", Password = HashPassword("1233"), Role = UserRole.Operator };
        var user3 = new User() { Login = "user", Password = HashPassword("1232"), Role = UserRole.User };

        context.Users?.Add(user1);
        context.Users?.Add(user2);
        context.Users?.Add(user3);

        context.SaveChanges();
    }
    
    private static string HashPassword(string password)
    {
        byte[] salt;
        
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
        var hash = pbkdf2.GetBytes(20);
        var hashBytes = new byte[36];
        
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        
        return Convert.ToBase64String(hashBytes);
    }
}