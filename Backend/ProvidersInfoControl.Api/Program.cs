using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PicDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

DbInitializer.Initialize(app);

app.MapGet("/", () => "Hello World!");

app.Run();