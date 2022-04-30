namespace ProvidersInfoControl.Domain.Dtos.Get;

public class ServiceGetDto : IGetDto
{
    public int Id { get; set; }
    public AbonentGetDto Abonent { get; set; }
    public double Size { get; set; }
    public string RecievingDate { get; set; }
}