using System.Text;
using Auth;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
    builder.Configuration.AddJsonFile("super_secret.json", false);
else 
{
    builder.Configuration.AddEnvironmentVariables("JwtKey");
    builder.Configuration.AddEnvironmentVariables("JwtIssuer");
    builder.Configuration.AddEnvironmentVariables("JwtAudience");
    builder.Configuration.AddEnvironmentVariables("DbConnection");
}
var config = builder.Configuration;
System.Console.WriteLine(config["JwtKey"]);
System.Console.WriteLine(config["JwtIssuer"]);
System.Console.WriteLine(config["JwtAudience"]);
System.Console.WriteLine(config["DbConnection"]);
builder.Services.AddAuthentication(x => 
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidIssuer = config["JwtIssuer"],
        ValidAudience = config["JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["JwtKey"]!)
        ),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy(PolicyData.AdminOnlyPolicyName, p => {
        p.RequireClaim(PolicyData.AdminClaimName, "true");
    });
});
builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql(config["DbConnection"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, DefaultTokenService>();
builder.Services.AddScoped<IPasswordService, BCryptPasswordService>();
builder.Services.AddScoped<IImageService, ImageService>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();