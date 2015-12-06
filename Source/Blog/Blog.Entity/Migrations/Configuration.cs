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
    }
}
