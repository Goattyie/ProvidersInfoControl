using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.TableCreators;

public class AbonentTypeCreator
{
    public static void Init(PicDbContext context)
    {
        var abonentType1 = new AbonentType() {Name = "Частная"};
        var abonentType2 = new AbonentType() {Name = "Собственная"};

        context.AbonentTypes?.Add(abonentType1);
        context.AbonentTypes?.Add(abonentType2);

        context.SaveChanges();
    }
}