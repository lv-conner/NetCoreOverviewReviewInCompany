using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreOverview.Filters
{
    public class CoreExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IMemoryCache _cache;
        public CoreExceptionFilter(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            _cache.TryGetValue<string>("filter", out var filterstr);
            filterstr += GetType().FullName;
            _cache.Set<string>("filter", filterstr);
            return Task.CompletedTask;
        }
    }
}
