namespace ProvidersInfoControl.Domain.Models;

public class OwnType : BaseModel
{
    public string Name { get; set; }
    public virtual ICollection<Firm> Firms { get; set; }
}