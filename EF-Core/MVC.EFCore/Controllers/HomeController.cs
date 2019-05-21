using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.EFCore.Models;
using MVC.EFCore.Services;

namespace MVC.EFCore.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Blog> blosg; //自定义泛型
        public readonly BloggingContext bloggingContext;
        // CTRO 快捷添加构造函数
        public HomeController(BloggingContext context)
        {
            bloggingContext = context;
        }
       
        public IActionResult Index()
        {

            using (var da = new BloggingContext())// 第一种 实例化 第二种可以在Controlle构造函数中注入
            //using (bloggingContext)
            {

                var blog = new Blog { Url = "http://baidu.com" };
                #region 构造函数创建 
                //bloggingContext.Blogs.Add(blog);
                //bloggingContext.SaveChanges();
                #endregion
                #region new 创建方式 不添加构造HomeController
                //da.Blogs.Add(blog);
                //da.SaveChanges();
                #endregion
                ViewBag.name = "完成！";
                return View(da.Blogs.ToList());
            }
           



        
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
