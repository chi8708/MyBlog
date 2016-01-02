using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Blog.Entity.Mapping.BlogContext>
    {
        public Configuration()
        {
            //自动迁移 数据库添加了 __MigrationHistory表
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            //  AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(Entity.Mapping.BlogContext context)
        {
            //var list = new List<ArticleCategory>{
            //new ArticleCategory(){Id="1",Name=".Net", ParentId="0",Level=1,CreateTime=DateTime.Now,IsDeleted=false},
            //new ArticleCategory(){Id="2",Name="Html", ParentId="0",Level=1,CreateTime=DateTime.Now,IsDeleted=false},
            //new ArticleCategory(){Id="3",Name="Javascript", ParentId="0",Level=1,CreateTime=DateTime.Now,IsDeleted=false},
            //new ArticleCategory(){Id="4",Name="SqlServer", ParentId="0",Level=1,CreateTime=DateTime.Now,IsDeleted=false},
            //new ArticleCategory(){Id="5",Name="软件架构", ParentId="0",Level=1,CreateTime=DateTime.Now,IsDeleted=false}
            //};

            //context.ArticleCategory.AddOrUpdate(new ArticleCategory() { Id = "1", Name = ".Net", ParentId = "0", Level = 1, CreateTime = DateTime.Now, IsDeleted = false });
            //context.ArticleCategory.AddOrUpdate(new ArticleCategory() { Id = "2", Name = "Html", ParentId = "0", Level = 1, CreateTime = DateTime.Now, IsDeleted = false });
            //context.ArticleCategory.AddOrUpdate(new ArticleCategory() { Id = "3", Name = "Javascript", ParentId = "0", Level = 1, CreateTime = DateTime.Now, IsDeleted = false });
            //context.ArticleCategory.AddOrUpdate(new ArticleCategory() { Id = "4", Name = "SqlServer", ParentId = "0", Level = 1, CreateTime = DateTime.Now, IsDeleted = false });
            //context.ArticleCategory.AddOrUpdate(new ArticleCategory() { Id = "5", Name = "软件架构", ParentId = "0", Level = 1, CreateTime = DateTime.Now, IsDeleted = false });

            base.Seed(context);
        }
    }
}
