using ProvidersInfoControl.Domain.Enums;

namespace ProvidersInfoControl.Domain.Models;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}