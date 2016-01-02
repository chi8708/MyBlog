using Blog.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
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

        }

        #region 用户
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserInfo_Role> UserInfo_Role { get; set; } 

        #endregion

        #region 文章
        public DbSet<Article> Article { get; set; }

        public DbSet<Article_Category> Article_Category { get; set; }

        public DbSet<ArticleCategory> ArticleCategory { get; set; }

        public DbSet<ArticleComment> ArticleComment { get; set; }

      //  public DbSet<VUserInfoRole> VUserInfoRole { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 禁用多对多关系表的级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

         //   modelBuilder.Configurations.Add(new VUserInforRoleMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
