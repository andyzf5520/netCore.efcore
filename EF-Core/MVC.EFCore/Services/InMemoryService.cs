using MVC.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.EFCore.Services
{
    public class InMemoryService : IRepository<Blog>
    {
        public readonly List<Blog> _Blogs;
        public InMemoryService()
        {
            _Blogs = new List<Blog>();
            _Blogs.Add(new Blog
            {
                Url = "wwww.baidadad.com",
            });
        }
    }

}
