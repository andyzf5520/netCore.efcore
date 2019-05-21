using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.EFCore.Models
{
    public class BloggingContext : DbContext
    {
        // 非必须的 因为继承了DbContext 所以下面这个代码应当重写了
        //public BloggingContext(DbContextOptions<BloggingContext> options) //子类的options传给父类构造函数
        //    : base(options)
        //{
        //    //必填重写子类重写就是给父类构造函数中传options 已经注册配置了

        //}
        //通过模型创建数据库细节
        //重写OnConfiguring方法，配置数据库连接 必填重写子类重写就是给父类构造函数中传options 已经注册配置了 
        // 也就是上下文给父类DBContext的方法OnConfiguring 参数DbContextOptionsBuilder中重写
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server =.; Database = BooksDB; Trusted_Connection = True;");
            optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = test; Integrated Security = True;");
            
            //base.OnConfiguring(optionsBuilder);
        }
        //重写OnModelCreating方法，配置创建model的约束条件 可选
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Blog>().ToTable("Blogs").HasKey(c => c.BlogId);
            //modelBuilder.Entity<Post>().ToTable("Posts").HasKey(c => c.PostId);
           

        }
        public BloggingContext()

        { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
      



    }


    public class Blog
    {
        [Required]
        public int BlogId { get; set; }
        //[Required]
        //[Column(TypeName = "varchar(200)")]
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        [Required]
        public int PostId { get; set; }
        //[Column(TypeName = "varchar(200)")]
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }



}
