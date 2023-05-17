using Azure.Storage.Blobs;
using Lumini.FireKeeper.Application;
using Lumini.FireKeeper.Application.Services.Upload;
using Lumini.FireKeeper.Data.Contexts;
using Lumini.FireKeeper.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lumini KeepFire Api",
        Version = "v1",
        Description = "The file drive management",
        Contact = new OpenApiContact
        {
            Name = "Lumini Tecnologia",
            Email = "contato@luminitec.com.br",
        },
        License = new OpenApiLicense
        {
            Name = "Lumini Tecnologia",
            Url = new Uri("https://www.luminitec.com.br")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var load = EnumExtensions.GetDescription;
var superAssemblies = AppDomain.CurrentDomain.GetLuminiLoadedAssemblies("Lumini.FireKeeper");

builder.Services.AddAutoMapper(superAssemblies);
builder.Services.AddLuminiMediator(superAssemblies);
builder.Services.AddLuminiPresenter();

// DI DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FireKeeperDb")).EnableSensitiveDataLogging());

// DI BlobStorageClient
builder.Services.AddScoped(_ => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage")));

// DI Services
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

var secret = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Secret").Value);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secret),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
