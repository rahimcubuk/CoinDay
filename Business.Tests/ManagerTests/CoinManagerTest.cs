using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq.Expressions;

namespace Business.Tests.ManagerTests
{
    [TestClass]
    public class CoinManagerTest
    {
        #region Moq_Sahte_Nesne_Oluşturma
        private static Coin _coin;
        private static Mock<ICoinDal> _mock = new Mock<ICoinDal>();
        private static ICoinService _coinManager = new CoinManager(_mock.Object);
        #endregion


        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassTestInitialize(TestContext testContext)
        {
            _coin = new Coin
            {
                CoinName = "ADA"
            };
        }

        [Description("Bir coin birden fazla kez eklenmememlidir.")]
        [TestMethod]
        public void CheckIfCoinNameExists()
        {
            #region Alarm
            _mock.Setup(m => m.IsExist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);
            #endregion
            var result = _coinManager.Add(_coin);

            TestContext.WriteLine("Test Name: {0}", TestContext.TestName);
            TestContext.WriteLine("Method Message: " + result.Message);
            TestContext.WriteLine("Method Success: " + result.Success);
            TestContext.WriteLine("Test Description: {0}", "Bir coin birden fazla kez eklenmememlidir.");

            Assert.IsFalse(result.Success);
        }
    }
}
