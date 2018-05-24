using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace NetCoreOverview.Controllers
{
    public class FilterController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IDistributedCache _distributedCache;
        public FilterController(IMemoryCache cache,IDistributedCache distributedCache)
        {
            _cache = cache;
            _distributedCache = distributedCache;
        }
        public IActionResult Index()
        {
            _cache.TryGetValue<string>("filter", out var filterStr);
            return Content(filterStr);
        }
    }
}