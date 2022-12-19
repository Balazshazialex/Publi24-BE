using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Publi24.Controllers;
using Publi24.Entities;
using Publi24.Services;
using System.Collections.Generic;

namespace Publi24
{
    [TestClass]
    public class TestClass
    {
        private ApplicationDbContext _dbContext { get; set; }
        public CompanyService companyService { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=publi24;Trusted_Connection=True")
                    .EnableSensitiveDataLogging()
                    .Options;
            _dbContext = new ApplicationDbContext(options);
            companyService = new CompanyService(_dbContext, new Mock<IMapper>().Object);
        }

        [TestMethod]
        public void testme()
        {
            var controller = new CompanyController(companyService);
            var taskGet = controller.GetList() as OkObjectResult;
            Assert.AreEqual(200, taskGet.StatusCode);
            Assert.IsInstanceOfType(taskGet.Value, typeof(List<Company>));
        }
    }
}
