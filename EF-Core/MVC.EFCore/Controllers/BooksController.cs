using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.EFCore.Models;

namespace MVC.EFCore.Controllers
{
    public class BooksController : Controller
    {

        //    工具 - > NuGet软件包管理器 - >软件包管理器控制台
        ////创建模型的初始表 
        //Add-Migration InitialCreate
        ////将新迁移应用于数据库 
        //Update-Database

        //这里我们利用ASP.NET Core的依赖注入来获取数据库上下文。
        public readonly BooksDBContext myDBContext;
        public BooksController(BooksDBContext _myDBContext)
        {
            myDBContext = _myDBContext;
            //myDBContext = new MyDBContext();//不需要 不然得传参数op
        }
        public IActionResult Index()
        {
            if (myDBContext.Authers.Count() == 0)
            {
                myDBContext.Add(new Book()
                {

                    Name = "三国演义",
                    Content = "三国",
                    AutherID = 2,
                    DateTime = DateTime.Now
                });

                myDBContext.Add(new Auther()
                {

                    //AutherID = 1,
                    Name = "齐白石"

                });
            }
          
         


            //myDBContext.SaveChanges();
            var modelDto= myDBContext.Books.Join(
                                myDBContext.Authers,
                                e1 => e1.AutherID,
                                e2 => e2.AutherID,
                                (e1, e2) => new
                                {
                                    e1,
                                    e2
                                }
                                ).Select(s => new
                                {
                                     s.e1.BookID,
                                     s.e1.Content,
                                     AuthorName = s.e2.Name,
                                }).ToList();
            var modelDto2 = from a in myDBContext.Books
                            join b in myDBContext.Authers
                            on a.AutherID equals b.AutherID
                            select new
                            {
                                a.BookID,
                                a.Content,
                                a.Name,
                                AuthorName = b.Name
                            } into c
                            group c by new { c.AuthorName } into d  //按照作家分组
                            select d;

            ViewBag.Message = "OK!";
            var list = myDBContext.Books.AsNoTracking(); //只进行查询
            ViewBag.Data = list.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var Authors = myDBContext.Authers.ToList();

            var listItems = new List<SelectListItem>();
            for (int i = 0; i < Authors.Count; i++)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = Authors[i].Name,
                    Value = Authors[i].AutherID.ToString()
                });
            }
            ViewBag.Names = listItems;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            int id = book.AutherID == 0 ? 1 : book.AutherID;
            book.AutherID = id;
            if (book != null)
            {
                //book.AutherID = id; // 不需要添加
                myDBContext.Add(book);
                //myDBContext.Books.Add(book);// 建议一般这样写 比较具体不用推断类型
                myDBContext.SaveChanges();
                //return RedirectToAction(nameof(Index));
            }




            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {



            var book = myDBContext.Books.Find(id);
            if (book != null)
            {
                myDBContext.Books.Remove(book);
                myDBContext.SaveChanges();// 必须保存不然删除没反应
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {

            return View();
        }
        public IActionResult Details(int id)
        {
            var data = myDBContext.Books.Find(id);
            return View(data);

        }
        public IActionResult Edit(int? id)
        {
            var data = myDBContext.Books.Find(id);
            if (data == null)
                return NotFound();

            return View(data);
        }


        [HttpPost]

        public ActionResult Edit(Book book)
        {

            if (book == null)
            {
                return new BadRequestResult();
            }

            if (ModelState.IsValid)
            {
                //var books=  myDBContext.Set<Book>().AsNoTracking();      //修改不能这么使用       
                //var books = myDBContext.Books.AsNoTracking(); //这样也不行
                //第一种修改方法
                //var books = myDBContext.Books.First(e => e.BookID == book.BookID);
                //books.Content = book.Content.Trim(); //这种虽然赋值给了books 变量 但是会追踪books变量变化 最后保存的也是修改的
                //                              //使用下面的Update(book);也可以直接修改

                #region 不推荐方法
                //Book data = myDBContext.Books .SingleOrDefault(e => e.BookID == book.BookID);
                //myDBContext.Entry(book).Property(p => p.Name).IsModified = true;//告诉EF Core实体person的Name属性已经更改。将testDBContext.Entry(person).Property(p => p.Name).IsModified设置为true后，也会将person实体的State值（可以通过testDBContext.Entry(person).State查看到）更改为EntityState.Modified，这样就保证了下面SaveChanges的时候会将person实体的Name属性值Update到数据库中。
                //myDBContext.Entry(book).Property(p => p.Content).IsModified = true;
                //myDBContext.Entry(book).Property(p => p.AutherID).IsModified = true;
                //myDBContext.Entry(book).Property(p => p.DateTime).IsModified = true; 
                #endregion
                // 第三种方法 直接接收后修改
                myDBContext.Books.Update(book);// 跟明源云一样必须改状态




                myDBContext.SaveChanges();//Linq to sql  数据上下文中的保存删除新增修改都是一个方法SubnitChanges()
                return RedirectToAction(nameof(Index));// 返回控制器名
            }
            myDBContext.SaveChanges();
            return View();

        }
    }
}