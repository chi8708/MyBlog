using Blog.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class BlogContext : DbContext
    {
        private const string CONNSTR = "MyBlogStr";
        //必须继承base 并把连接字符串传入
        public BlogContext()
            : base(CONNSTR)
        {
            //自动更新数据库 不用运行 update-database 命令。
            Database.SetInitializer<BlogContext>(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>(CONNSTR));

            // this.Configuration.ProxyCreationEnabled = true;
            // this.Configuration.LazyLoadingEnabled = true; 默认为true
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 禁用多对多关系表的级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

        }
    }
}
