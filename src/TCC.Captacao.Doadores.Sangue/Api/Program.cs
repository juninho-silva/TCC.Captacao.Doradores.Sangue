using Api.DTOs;
using Api.DTOs.v1.Campaign;
using Api.DTOs.v1.Donor;
using Api.DTOs.v1.Organization;
using Api.Infrastructure.Auth;
using Api.Infrastructure.Data.Repositories;
using Api.Infrastructure.Data.Repositories.Campaign;
using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Data.Repositories.Organization;
using Api.Infrastructure.Data.Repositories.User;
using Api.Infrastructure.Smtp;
using Api.Services.v1;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var secret = builder.Configuration.GetValue<string>("JwtSettings:Secret");
var key = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddAutoMapper(
    typeof(OrganizationProfile).Assembly,
    typeof(DonorProfile).Assembly,
    typeof(CampaignProfile).Assembly
);

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddAuthorization();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API - Captação de Doadores de Sangue",
        Version = "v1",
        Description = "Sistema de Captação de Doadores de Sangue",
        Contact = new OpenApiContact
        {
            Email = "juninho.silva.goncalves@gmail.com",
            Name = "Fabio Junio"
        }
    });

    // adiciona documentacao
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));

builder.Services.AddScoped(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
