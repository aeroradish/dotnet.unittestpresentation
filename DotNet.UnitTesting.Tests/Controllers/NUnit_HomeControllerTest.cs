using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit;
using NUnit.Framework;
using DotNet.UnitTesting.Web;
using DotNet.UnitTesting.Web.Controllers;
using DotNet.UnitTesting.DAL;
using DotNet.UnitTesting.Logic;
using DotNet.UnitTesting.Models;

namespace DotNet.UnitTesting.Tests.Controllers
{
    [TestFixture]
    public class NUnit_HomeControllerTest
    {
        [Test]
        public void NUnit_MakePayment_Pass_PaymentCorrect()
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
    }
}
