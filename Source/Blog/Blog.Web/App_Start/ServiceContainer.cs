using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Blog.Service.Impl;


namespace Blog.Web
{
    public class ServiceContainer
    {
        private static object o = new object();
        private static ContainerBuilder containerBuilder = null;
        public static void RegisterContainer()
        {
            if (containerBuilder == null)
            {
                lock (o)
                {
                    containerBuilder = new ContainerBuilder();

                     containerBuilder.RegisterAssemblyTypes(typeof(ArticleService).Assembly)
                         .Where(t =>t.BaseType!=null&&t.BaseType.Name.StartsWith("BaseService"))
                         .AsImplementedInterfaces().InstancePerLifetimeScope();

                }
            }

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());  //注入所有Controller
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //解决Controller 没有为该对象定义无参数的构造函数
        }

    }
}
