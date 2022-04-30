namespace ProvidersInfoControl.Domain.Models;

public class AbonentType : BaseModel
{
    public string Name { get; set; }
    public virtual ICollection<Abonent> Abonents { get; set; }
}