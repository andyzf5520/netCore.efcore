using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore_CodeFirst
{
   public class MyDBContext:DbContext
    {
        // 注意此方法在MVC中采用 控制台不需要也可以 【table("Blogs")】也不需要加
        // base表示调用父类构造函数 DbContext([NotNullAttribute] DbContextOptions options);
        //public MyDBContext(DbContextOptions<MyDBContext> options) //形参   
        //    : base(options)
        //{  // 实参
        //本地配置文件配置的话直接使用下面这个添加
        //configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //}
        //public Sphere(double r) : base(r, 0) //调用父类的有参数方法
        //调用父类方法的时候必须重写父类方法 其中方法必须为虚方法或者抽象方法
        //{
        //}
        // 下面DBSet集合为Blogs创建的表名
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        private IConfiguration configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           string Constr= configuration.GetConnectionString("Constr");
            if (!optionsBuilder.IsConfigured)
            {
  // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=test;Integrated Security=True;");
            }
        }

        // 下面的也不需要 在MVC中加 
        //重写OnModelCreating方法，配置创建model的约束条件(前提是使用Add-Migration InitialCreate Update-Database )

        //注意： 此添加的必须的非常重要:  Add-Migration InitialCreate 
        //将新迁移应用于数据库  Update-Database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Blog>(entity =>
            //{
            //    entity.Property(e => e.Url).IsRequired();
            //});

            //entity.Property(e => e.Author)
            //      .IsRequired()
            //      .HasMaxLength(200);
            //modelBuilder.Entity<Post>(entity =>
            //{
            //    entity.HasOne(d => d.Blog)
            //        .WithMany(p => p.Posts)
            //        .HasForeignKey(d => d.BlogId);
            //});
        }
    }
}
