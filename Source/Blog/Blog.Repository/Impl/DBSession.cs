using Blog.IRepository;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public partial class DBSession:IDBSession
    {

        //当前EF上下午文
        public DbContext CurrentEFContext { get; set; }

        private IDBContextFactory dbContextFactory = new EFContextFactory();

        public DBSession()
        {
            this.CurrentEFContext = dbContextFactory.GetCurrentContextInstence();
        }

        public int ExcuteSql(string sql, params System.Data.SqlClient.SqlParameter[] parameters)
        {
            return CurrentEFContext.Database.ExecuteSqlCommand(sql,parameters);

        }

        //调用当前  的线程内唯一实例的 EF上下文，保存回数据库
        public int SaveChanges()
        {
            return this.CurrentEFContext.SaveChanges();
        }

        public Task<int> SaveChagesAsync() 
        {
            return  this.CurrentEFContext.SaveChangesAsync();
        }

        public void DisposeDBContext()
        {
            if (CurrentEFContext!=null)
            {
                CurrentEFContext.Dispose();
            }
        }
    }
}
