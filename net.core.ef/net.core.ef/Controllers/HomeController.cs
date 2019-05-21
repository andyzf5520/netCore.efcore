using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net.core.ef.Models;

namespace net.core.ef.Controllers
{


    //    工具 - > NuGet软件包管理器 - >软件包管理器控制台
    ////创建模型的初始表 
    //Add-Migration InitialCreate
    ////将新迁移应用于数据库 
    //Update-Database
    public class HomeController : Controller
    {
        //这里我们利用ASP.NET Core的依赖注入来获取数据库上下文。
        public readonly MyDBContext myDBContext;
        public HomeController(MyDBContext _myDBContext)
        {
            myDBContext = _myDBContext;
            //myDBContext = new MyDBContext();//不需要 不然得传参数op
        }
        public IActionResult Index()
        {
            myDBContext.Add(new Book()
            {

                Name = "三国演义",
                Content = "三国",
                AutherID=1,
                DateTime=DateTime.Now
            });

            myDBContext.SaveChanges();
            ViewBag.Message = "OK!";
            var list = myDBContext.Books;
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
