using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.EFCore.Models
{
    public class BooksDBContext : DbContext
    {
        // 创建名称不同的多个DBContext时候需要添加如下参数 cmd 命令行执行dotnet ef migrations add Initial -c DemoDbContext
        //  如在原命令后加上代码-c DbContext的文件名，如下
        //执行命令生成创建的文件
        //dotnet ef migrations add Initial -c DemoDbContext
        //执行命令生成数据库
        //dotnet ef database update -c DemoDbContext
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther>Authers {get;set;}
        //重写OnConfiguring方法，配置数据库连接(可选)
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=BooksDB ;Trusted_Connection=True;");
        //}

    }
    public class Book
    {
        public int BookID { get; set; }
        public int AutherID { get; set; }
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }
        public Auther Auther { get; set; }


    }

    public class Auther
    {
        public int AutherID { get;  set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
