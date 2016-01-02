using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IRepository
{
    public partial interface IDBSession
    {
        int ExcuteSql(string sql, params SqlParameter[] parameters);

        int SaveChanges();

        Task<int> SaveChagesAsync();

        void DisposeDBContext();
    }
}
