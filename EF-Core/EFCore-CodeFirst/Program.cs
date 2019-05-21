using System;

namespace EFCore_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 第一步：先安装 Microsoft.EntityFrameworkCore (非必须)再安装带.sqlserver的
            ////提供熟悉的Add-Migration，Update-Database等Powershell命令，不区分关系型数据库类型
            ///执行命令是以 install 
            //Install - Package Microsoft.EntityFrameworkCore.Tools
            // ef-core 安装： 1.先检查vs2017Nuget中搜索看是否能搜索到EntityFrameWorkCore 搜索不到就需要配置Nuget数据源
            // 地址：https://api.nuget.org/v3/index.json 并设置搜索选项选择第一个搜索 
            // 之后通过搜索安装或者使用Nuget PM 命令行安装 
            // 

            //.NET Core CLI 执行命令是以dotnet 开始dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            // 在操作系统的命令行中使用以下.NET Core CLI 命令来安装或更新 EF Core SQL Server 提供程序：
            //dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            // 2 . 使用Visual Studio NuGet 包管理器控制台PM
            //Install-Package Microsoft.EntityFrameworkCore.SqlServer
            // 第二部创建类数据上下文 并添加配置文件aspsettings.json 使用vs自带数据库连接数据库查看
            // F4查看连接字符串


            /*  1 EF Core实体框架核心安装：

            工具> NuGet软件包管理器>软件包管理器控制台

            Install-Package Microsoft.EntityFrameworkCore.SqlServer

            Install-Package Microsoft.EntityFrameworkCore.Tools

            Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

            原文：https://blog.csdn.net/G_Q_L/article/details/77506220 
           2.  在startup.cs的ConfigureServices方法中中将上下文类注册为全局服务: 
           控制台的话就是main函数入口写入
            services.AddDbContext(options => options.UseSqlServer(connection));

            在appsetting文件中增加连接字符串connection

           3. 创建数据库  这个步骤很重要不执行添加 Blogs为空报错 一下方法就是执行增删改查的操作sql
            工具 - > NuGet软件包管理器 - >软件包管理器控制台 
            //创建模型的初始表 
            Add-Migration InitialCreate 
            //将新迁移应用于数据库 
            Update-Database
             //若要启用延迟加载，可以创建导航属性 virtual（Blog.Post 和 Post.Blog）。修饰blog字段属性
             */
            using (var db = new MyDBContext())
            {
                var blog = new Blog { Url = "http://baidu.com" };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }


            Console.WriteLine("OK!");
            Console.Read();
        }
    }
}
