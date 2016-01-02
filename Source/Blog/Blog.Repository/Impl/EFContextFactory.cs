using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    internal class EFContextFactory : IDBContextFactory
    {
        private readonly object o = new object();
        static DbContext dbContext = null;
        public  DbContext GetCurrentContextInstence()
        {

            dbContext = (DbContext)CallContext.GetData(typeof(EFContextFactory).FullName);

            //首次加载线程槽无数据
            if (dbContext == null)
            {
                lock (o)
                {
                    if (dbContext == null)
                    {
                        //获取实例把实例放入线程槽中
                        dbContext = new BlogContext();
                        CallContext.SetData(typeof(EFContextFactory).FullName, dbContext);
                        EFProLoad();
                        Task.Run(()=> EFProLoad());
                    }

                }
            }

            return dbContext;
        }

        //EF预加载（EF6.0+），还未对数据进行操作时就做映射。 单元测试 速度提升10倍
        private static void EFProLoad()
        {
            if (dbContext!=null)
            {
                var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
    }
    
}
