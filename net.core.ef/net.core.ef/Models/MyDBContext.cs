using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net.core.ef.Models
{
    public class MyDBContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options) {

        }
        //重写OnConfiguring方法，配置数据库连接(可选)
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=BooksDB ;Trusted_Connection=True;");
        //}

    }
    public class Book {
        public int BookID { get; set; }
        public int AutherID { get;  set; }
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }
        public Auther Auther { get; set; }
       

    }

    public class Auther {
        public int AutherID { get; private set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
