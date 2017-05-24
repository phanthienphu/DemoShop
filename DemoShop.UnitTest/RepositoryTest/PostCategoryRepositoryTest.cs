using DemoShop.Data.Infrastructure;
using DemoShop.Data.Repositories;
using DemoShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DemoShop.UnitTest.RepositoryTest
{
    [TestClass] //Hiển thị case ở màn hình TestExplorer
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize] //khởi chạy khi chạy project
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "Test Category";
            category.Status = true;

            var resuilt = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(resuilt);//Test not null => success
            Assert.AreEqual(3, resuilt.ID);
        }

    }
}