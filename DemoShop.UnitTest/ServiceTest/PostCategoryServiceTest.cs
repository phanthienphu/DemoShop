
using DemoShop.Data.Infrastructure;
using DemoShop.Data.Repositories;
using DemoShop.Model.Models;
using DemoShop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();//Tạo ra 1 đối tượng giả cho Repository
            _mockUnitOfWork = new Mock<IUnitOfWork>();//Tạo ra đối tượng giả cho unit of work
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID = 1, Name = "DM1", Status = true },
                new PostCategory() {ID = 2, Name = "DM2", Status = true },
                new PostCategory() {ID = 3, Name = "DM3", Status = true },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var resuilt = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(resuilt);//test not null => success
            Assert.AreEqual(3, resuilt.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test";
            category.Alias = "Test";
            category.Status = true;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
              {
                  p.ID = 1;
                  return p;
              });

            var resuilt = _categoryService.Add(category);

            Assert.IsNotNull(resuilt);
            Assert.AreEqual(1, resuilt.ID);
        }
    }
}
