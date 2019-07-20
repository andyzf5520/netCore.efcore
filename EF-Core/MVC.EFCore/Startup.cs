using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.EFCore.Models;

namespace MVC.EFCore
{
    public class Startup
    {
        /*
         * 
         * DBFirst 
         * 方式一：通过现有数据库创建模型：

            工具 - >连接到数据库…,选择Microsoft SQL Server 添加数据库连接
            工具 - > NuGet软件包管理器 - >软件包管理器控制台
            注意：下面的 Server=(localdb)\mssqllocaldb 指的是vs自带的数据库，如果要使用本地SQLServer的话那么需要换成 “.”或 “localhost”。Trusted_Connection=True使用的是window身份验证，
            如果要使用账户密码的话，请换成Uid和Pwd.
            原文：https://blog.csdn.net/G_Q_L/article/details/77506220 
            Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=[YourDatabase];Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

         * 方式二 : COde-First
        新建一个APS.NET CORE WEB模板项目
        安装相关Nuget包
        //Sql Server Database Provider
        Install-Package Microsoft.EntityFrameworkCore.SqlServer
    
        //提供熟悉的Add-Migration，Update-Database等Powershell命令，不区分关系型数据库类型
        Install-Package Microsoft.EntityFrameworkCore.Tools  
        Tools工具用来使 options.UseSqlServer 可以使用的作用
        // 新增配置信息Constr 

        创建数据库 
        工具 - > NuGet软件包管理器 - >软件包管理器控制台 
        //创建模型的初始表 
        Add-Migration InitialCreate 或者InitialDB 创建新数据库 必须切换到当前项目目录下执行 
        Add-Migration InitialCreate -c  DemoDbContext  或者使用Update-Database -context BooksDBContext   Add-Migration -context BooksDBContext initialize
        //将新迁移应用于数据库 
        Update-Database  为任何待定的模型更改 搭建迁移脚本。也就是SQL 创建或者更新对应表到数据库（空表） 
        Update-Database -c DemoDbContext 执行多个上下文对象使用

        // 数据库删除了也可以更新 不用执行上面Migrations步骤
        
             */
        public Startup(IConfiguration configuration)// 构造函数注入变量接口
        {
            Configuration = configuration;
        }

        public  IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var con = Configuration["ConnectionStrings:Constr"];
           

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //必填重写子类重写就是给父类构造函数中传options 已经注册配置了
            // 以下的链接方法有两种字符串
            var str = @"Data Source=.;Initial Catalog=test;Integrated Security=True;";
            var connection = @"Server=.;Database=test;Trusted_Connection=True;";

            //数据上下文添加数据库配置这里就不需要添加了
            services.AddDbContext<BloggingContext>();
            //services.AddDbContext<BloggingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Constr")));

            // 方法2 推荐 
            services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Constr")));
        }

     
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
