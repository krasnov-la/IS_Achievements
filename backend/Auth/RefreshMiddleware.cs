using System.Buffers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace backend.Auth;
public class RefreshMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, ITokenService tokenService, IUnitOfWork unit)
    {
        var indicate = context.Request.Cookies["exp"];
        var token = context.Request.Cookies["cookie-1"];
        bool auth = true;
        if (string.IsNullOrEmpty(indicate))  
        {
            var refresh = context.Request.Cookies["cookie-2"];
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refresh))
            {
                var claims = tokenService.GetPrincipalFromExpToken(token);
                var login = claims.First(c => c.Type == "Login").Value;
                var user = await unit.Users.GetById(login);
                if (user is null || user.Refresh != refresh || user.RefreshExpire > DateTime.Now)
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                user.Refresh = tokenService.GenerateRefreshToken();
                user.RefreshExpire = DateTime.Now.AddDays(5);

                unit.Users.Update(user);

                await unit.SaveAsync();

                token = tokenService.GenerateAccessToken(claims);

                context.Response.Cookies.Append("exp", "somescaryhash", new(){
                    Expires = DateTime.Now.AddMinutes(10)
                });
                context.Response.Cookies.Append("cookie-1", token);
                context.Response.Cookies.Append("cookie-2", user.Refresh, new(){
                    Expires = user.RefreshExpire
                });
            }
            else 
                auth = false;
        }
    
        if (auth)
            context.Request.Headers.Append("Authorization", "Bearer " + token);

        await _next.Invoke(context);
    }
}