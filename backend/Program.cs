using System.Text;
using Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAuthentication(x => 
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, DefaultTokenService>();


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