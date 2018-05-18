using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace NetCoreOverview.Filters
{
    public class CoreAuthorizedFilter : IAsyncAuthorizationFilter,IAuthorizationFilter
    {
        private readonly IMemoryCache _cache;
        public CoreAuthorizedFilter(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            OnAuthorizationAsync(context).GetAwaiter().GetResult();
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _cache.TryGetValue<string>("filter", out var filterstr);
            filterstr += GetType().FullName;
            _cache.Set<string>("filter", filterstr);
            return Task.CompletedTask;
            if (SkipAuthorization(context))
            {
                return Task.CompletedTask;
            }
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }
            else
            {
                OnUnAuthorizatioin(context);
                return Task.CompletedTask;
            }
        }

        public bool SkipAuthorization(AuthorizationFilterContext context)
        {
            return context.Filters.Any(p => p as IAllowAnonymousFilter != null);
        }
        public void OnUnAuthorizatioin(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                context.Result = new JsonResult(new { message = "Need Autorization!", code = 401 });
            }
            else
            {
                //Will call default authentication scheme
                context.Result = new ChallengeResult();
            }
        }
    }
}
