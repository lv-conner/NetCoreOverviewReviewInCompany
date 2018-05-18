using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace NetCoreOverview.Filters
{
    public class CoreResourceFilter : IAsyncResourceFilter
    {
        private readonly IMemoryCache _cache;
        public CoreResourceFilter(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _cache.TryGetValue<string>("filter", out var filterstr);
            filterstr += GetType().FullName;
            _cache.Set<string>("filter", filterstr);
            return next();
        }
    }
}
