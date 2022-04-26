using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.TableCreators;

public class OwnTypeCreator
{
    public static void Init(PicDbContext context)
    {
        var ownType1 = new OwnType() {Name = "Частная"};
        var ownType2 = new OwnType() {Name = "Собственная"};

        context.OwnTypes?.Add(ownType1);
        context.OwnTypes?.Add(ownType2);

        context.SaveChanges();
    }
}