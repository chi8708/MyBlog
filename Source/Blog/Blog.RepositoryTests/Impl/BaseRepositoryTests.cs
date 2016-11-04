using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.IRepository;
using Blog.Entity.Mapping;
namespace Blog.Repository.Impl.Tests
{
    [TestClass()]
    public class BaseRepositoryTests
    {
        IUserInfoRepository dal = new UserInfoRepository();
        IDBSession dbsession = new DBSession();
        IVUserInfoRoleRepository viewDal = new VUserInfoRoleRepository();
        [TestMethod()]
        public void AddEntityTest()
        {
            //var data= viewDal.LoadEntity(p=>true).ToList();
            //int count = data.Count();

            UserInfo user = new UserInfo()
            {
                UserName = "test8",
                Password = "1235",
                CreateTime = DateTime.Now,
                Email = "aaa@qq.com"
            };
            dal.AddEntity(user);
            Assert.IsTrue(dbsession.SaveChanges() > 0);
        }

        [TestMethod()]
        public void UpdateEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadPageEntityTest()
        {
            Assert.Fail();
        }
    }
}
