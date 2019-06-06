## ef-core code first 创建 并进行数据迁移 生成实体上下文

 + DBFirst 

          方式一：通过现有数据库创建模型：

            工具 - >连接到数据库…,选择Microsoft SQL Server 添加数据库连接
            工具 - > NuGet软件包管理器 - >软件包管理器控制台
            注意：下面的 Server=(localdb)\mssqllocaldb 指的是vs自带的数据库，如果要使用本地SQLServer的话那么需要换成 “.”或 “localhost”。Trusted_Connection=True使用的是window身份验证，
            如果要使用账户密码的话，请换成Uid和Pwd.
            原文：https://blog.csdn.net/G_Q_L/article/details/77506220 
            Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=[YourDatabase];Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            
           </center>

+ 方式二 : COde-First
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
        Add-Migration InitialCreate -c  DemoDbContext
        //将新迁移应用于数据库 
        Update-Database  为任何待定的模型更改 搭建迁移脚本。也就是SQL 创建或者更新对应表到数据库（空表） 
        Update-Database -c DemoDbContext 执行多个上下文对象使用

        // 数据库删除了也可以更新 不用执行上面Migrations步骤
       
