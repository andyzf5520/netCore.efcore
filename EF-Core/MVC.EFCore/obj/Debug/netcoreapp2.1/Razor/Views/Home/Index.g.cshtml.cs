#pragma checksum "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0090c4d6247d8d08e836a53c90a25d93551ec29d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\_ViewImports.cshtml"
using MVC.EFCore;

#line default
#line hidden
#line 2 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\_ViewImports.cshtml"
using MVC.EFCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0090c4d6247d8d08e836a53c90a25d93551ec29d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c133e4dc061e4b9cffba9f915cce9e9b366ea948", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(64, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(69, 12, false);
#line 5 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
Write(ViewBag.name);

#line default
#line hidden
            EndContext();
            BeginContext(81, 285, true);
            WriteLiteral(@"</h1>
<div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"" data-interval=""6000"">
    <p>
        参考地址：https://www.cnblogs.com/stulzq/p/7717873.html
       创建名称不同的多个DBContext时候需要添加如下参数 cmd 命令行执行dotnet ef migrations add Initial -c DemoDbContext<br />

    </p>
    <p>");
            EndContext();
            BeginContext(367, 42, false);
#line 12 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
  Write(Html.ActionLink(" 新增 ", "index", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(409, 5, true);
            WriteLiteral(";    ");
            EndContext();
            BeginContext(415, 48, false);
#line 12 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
                                                  Write(Html.ActionLink("  跳转Books列表", "index", "Books"));

#line default
#line hidden
            EndContext();
            BeginContext(463, 133, true);
            WriteLiteral(";</p>\r\n\r\n\r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>ID</th>\r\n            <th>Url</th>\r\n           \r\n        </tr>\r\n\r\n");
            EndContext();
#line 22 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(645, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(676, 34, false);
#line 25 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(id => item.BlogId));

#line default
#line hidden
            EndContext();
            BeginContext(710, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(734, 33, false);
#line 26 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(mode => item.Url));

#line default
#line hidden
            EndContext();
            BeginContext(767, 53, true);
            WriteLiteral("</td>\r\n          \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(821, 65, false);
#line 29 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(886, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(907, 71, false);
#line 30 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(978, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(999, 69, false);
#line 31 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 34 "D:\工作\TFS\EF-Core\MVC.EFCore\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1115, 727, true);
            WriteLiteral(@"

    </table>
    <b>
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
        //将新迁移应用于数据库
        Update-Database  为任何待定的模型更改 搭建迁移脚本。也就是SQL 创建或者更新对应表到数据库（空表）
    </b>
    <input type=""range"" name=""points"" min=""1"" max=""1000"" value=""12121"" />
</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; }
    }
}
#pragma warning restore 1591