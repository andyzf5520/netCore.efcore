using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore_CodeFirst
{
    //[Table("Blogs")] //创建表名跟下面的Blogs一样
    public class Blog
    {
        // 第二步：
        public int BlogId { get; set; }
        public string Url { get; set; }
        //public virtual List<Post> Posts { get; set; }
        //若要启用延迟加载，可以创建导航属性 virtual（Blog.Post 和 Post.Blog）。
        public  List<Post> Posts { get; set; } //可以设置Virtual方便以后重写设置字段的值
    }
   
    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only
        // provide specialized behavior if they implement get and set accessors.
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
        public virtual int  BaseMethod(int a,int b)
        {
            return a * b;
        }
    }


    class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass():base() {
        }
        private string name;

        // Override auto-implemented property with ordinary property
        // to provide specialized accessor behavior.
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != String.Empty)
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }

        // /调用父类方法的时候必须重写父类方法 其中方法必须为虚方法或者抽象方法
        //1.this是标识当前资源对象的，而base是基于父级的。
        //2.base发挥了期灵魂级的作用——多态
        //3.base子类可以访问父类成员
        //4.base调用父类方法必须重写父类方法
        //5.base子类构造函数直接访问：base父类构造方法
        //6.base同样不能用于静态方法
        public override int BaseMethod(int a, int b)
        {
            return base.BaseMethod(a, b);
        }

    }
}
