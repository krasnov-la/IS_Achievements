using System.Buffers;
using System.Reflection.Emit;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Auth;

//Я ЗНАЮ, ЧТО GOTO ЭТО ХАРАМ, НО ЗДЕСЬ ЭТО УПРОЩАЕТ КОД, ЧЕСТНО!!!! 
public class RefreshMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, ITokenService tokenService, IUnitOfWork unit)
    {
        var indicate = context.Request.Cookies["exp"];
        var token = context.Request.Cookies["cookie-1"];
        var refresh = context.Request.Cookies["cookie-2"];
        
        if (refresh is null || token is null) goto End;

        if (indicate is not null) goto AddHeaderThenEnd;

        var claims = tokenService.GetPrincipalFromExpToken(token);
        var login = claims.First(c => c.Type == "Login").Value;
        var user = 
            await unit.Users
            .GetQuerable()
            .AsNoTracking()
            .Where(u => u.Login == login)
            .FirstOrDefaultAsync();

        if (user is null || user.Refresh != refresh || user.RefreshExpire < DateTime.Now)
            goto End;

        //Refresh

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
    
        AddHeaderThenEnd:
        context.Request.Headers.Append("Authorization", "Bearer " + token);
        End:
        await _next.Invoke(context);
    }
}