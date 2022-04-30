using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProvidersInfoControl.Database.TableCreators;

namespace ProvidersInfoControl.Database;

public class DbInitializer
{
    public static void Initialize(IHost host)
    {
        var config = host.Services.GetRequiredService<IConfiguration>();
        var connectionString = config.GetConnectionString("DefaultConnection");
        var serviceCollection = new ServiceCollection();

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new NullReferenceException();
        }

        serviceCollection.AddDbContext<PicDbContext>(opt => opt.UseNpgsql(connectionString));

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<PicDbContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        UserCreator.Init(dbContext);
        OwnTypeCreator.Init(dbContext);
        AbonentTypeCreator.Init(dbContext);
        AbonentCreator.Init(dbContext);
        FirmCreator.Init(dbContext);
        ContractCreator.Init(dbContext);
        ServiceCreator.Init(dbContext);
    }
}