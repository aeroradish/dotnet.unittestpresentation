using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNet.UnitTesting.Web;
using DotNet.UnitTesting.Web.Controllers;
using DotNet.UnitTesting.DAL;
using DotNet.UnitTesting.Logic;
using DotNet.UnitTesting.Models;
using Moq;

namespace DotNet.UnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Lazy title for Unit Testing presentation.", result.ViewBag.Message);
        }

        [TestMethod]
        public void MakePayment_Pass_PaymentCorrect()
        {
            // Arrange
            Repository repo = new Repository();
            var mockRepository = new Mock<ILoanModelDAL>();

            PaymentModel pay = new PaymentModel();
            pay.LoanID = 1;
            pay.PaymentAmount = 75;

            LoanModel loan = new LoanModel();
            loan.LoanID = 1;
            loan.Amount = 100;

            int id = 1;

            // tell the mock that when LoanSelectByID is called,
            // return the specified Loan
            mockRepository.Setup(cr => cr.LoanSelectByID(id)).Returns(loan);

            // pass the mocked instance, not the mock itself, to the category
            // controller using the Object property
            repo.iLoanModelDAL = mockRepository.Object;

            // Act
            LoanLogic loanLogic = new LoanLogic(repo);
            bool result = loanLogic.AttemptPayment(pay);

            // Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void MakePayment_Fail_PaymentTooLarge()
        {
            // Arrange
            Repository repo = new Repository();
            var mockRepository = new Mock<ILoanModelDAL>();

            PaymentModel pay = new PaymentModel();
            pay.LoanID = 1;
            pay.PaymentAmount = 500;

            LoanModel loan = new LoanModel();
            loan.LoanID = 1;
            loan.Amount = 100;

            int id = 1;

            // tell the mock that when LoanSelectByID is called,
            // return the specified Loan
            mockRepository.Setup(cr => cr.LoanSelectByID(id)).Returns(loan);

            // pass the mocked instance, not the mock itself, to the category
            // controller using the Object property
            repo.iLoanModelDAL = mockRepository.Object;

            HomeController controller = new HomeController(repo);

            // Act
            ViewResult result = controller.MakePayment(pay) as ViewResult;

            // Assert
            Assert.IsFalse(result.ViewBag.PaymentResult);

        }

        [TestMethod]
        public void CalculatePayment_ThrowError_Fail()
        {

            // Arrange
            Repository repo = new Repository();
            var mockRepository = new Mock<ILoanModelDAL>();

            PaymentModel pay = null;

            try
            {

                LoanLogic loanLogic = new LoanLogic(repo);
                bool result = loanLogic.CalculatePayment(pay);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "TestError");
            }
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Contact() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }
    }
}
