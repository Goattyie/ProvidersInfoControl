using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProvidersInfoControl.Bll;
using ProvidersInfoControl.Bll.Services;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Bll.Utils;
using ProvidersInfoControl.Dal;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Database;
using ProvidersInfoControl.Tools.MappingConfiguration;

var builder = WebApplication.CreateBuilder(args);

#region AutoMapper

builder.Services.AddAutoMapper(typeof(DtoModelProfile));

#endregion

#region Database Pic

builder.Services.AddDbContext<PicDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Repositories

builder.Services.AddScoped<IOwnTypeRepository, OwnTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAbonentTypeRepository, AbonentTypeRepository>();
builder.Services.AddScoped<IAbonentRepository, AbonentRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IFirmRepository, FirmRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();

#endregion

#region Services

builder.Services.AddScoped<IOwnTypeService, OwnTypeService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IAbonentTypeService, AbonentTypeService>();
builder.Services.AddScoped<IAbonentService, AbonentService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IFirmService, FirmService>();
builder.Services.AddScoped<IContractService, ContractService>();

#endregion

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

#endregion

#region Api

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,

            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

#endregion

var app = builder.Build();

DbInitializer.Initialize(app);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();