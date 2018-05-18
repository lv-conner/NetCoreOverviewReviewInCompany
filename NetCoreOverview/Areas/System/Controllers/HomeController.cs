using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreOverview.Areas.System.Controllers
{
    //必须使用AreaAttribute标记控制器所属区域，否则Asp.net core会因为找到多于一个控制器而报错。
    [Area("System")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}