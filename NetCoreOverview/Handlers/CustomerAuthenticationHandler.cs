using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace NetCoreOverview.Handler
{
    //IAuthenticationRequestHandler
    //IAuthenticationRequestHandler 实现此接口，将会捕获所有的请求，进行处理 并且HandleRequestAsync中如果返回ture将会中断整个处理流程。
    //IAuthenticationHandler 实现此接口，只有该处理器被定义为默认或者请求符合对应的模式才会捕获到请求进行处理
    public class CustomerAuthenticationHandler : IAuthenticationRequestHandler
    {
        private readonly HttpContext context;
        public CustomerAuthenticationHandler(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor.HttpContext;
        }
        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            if(context.Request.Cookies["Token"] == null)
            {
                return AuthenticateResult.Fail("No Token");
            }
            var token = context.Request.Cookies["Token"];
            var identity = new GenericIdentity("tim");
            var claim = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(claim, "Lfg");
            var result = AuthenticateResult.Success(ticket);
            return await Task.FromResult(result);
        }

        public async Task ChallengeAsync(AuthenticationProperties properties)
        {
            await Task.CompletedTask;
        }

        public async Task ForbidAsync(AuthenticationProperties properties)
        {
            await Task.CompletedTask;
        }

        public async Task<bool> HandleRequestAsync()
        {
            return await Task.FromResult(false);
        }

        public async Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            await Task.CompletedTask;
        }
    }
}
