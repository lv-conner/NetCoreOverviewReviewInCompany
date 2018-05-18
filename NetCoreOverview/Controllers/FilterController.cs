using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace NetCoreOverview.Controllers
{
    public class FilterController : Controller
    {
        private readonly IMemoryCache _cache;
        public FilterController(IMemoryCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            _cache.TryGetValue<string>("filter", out var filterStr);
            return Content(filterStr);
        }
    }
}