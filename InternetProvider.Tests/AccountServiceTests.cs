using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Data.Repositories;
using InternetProvider.Logic.Infrastructure;
using InternetProvider.Logic.Interfaces;
using InternetProvider.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace InternetProvider.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
       [TestMethod]
        [ExpectedException(typeof(ValidationException),
        "Withdrawn value cannot be negative")]
        public void Withdraw_NegativeAsParameter_ThrowsException()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new AccountService(mockUnitOfWork.Object);

            service.Withdraw("id", -100.00);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException),
        "Added value cannot be negative")]
        public void AddToBalance_NegativeAsParameter_ThrowsException()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new AccountService(mockUnitOfWork.Object);

            service.AddToBalance("id", -100.00);
        }
    }
}
