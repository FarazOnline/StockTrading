using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using StockTrader.Domain.Exceptions;
using StockTrader.Domain.Models;
using StockTrader.Domain.Services;
using StockTrader.Domain.Services.AuthServices;
using System.Threading.Tasks;

namespace StockTrader.Domain.Tests.Services.AuthServices
{
    [TestFixture]
    public class AuthServiceTests
    {
        private Mock<IPasswordHasher> _MkPWHash;
        private Mock<ILoginService> _MkLogServ;
        private AuthService _AS;

        [SetUp]
        public void SetUp()
        {
            _MkPWHash = new Mock<IPasswordHasher>();
            _MkLogServ = new Mock<ILoginService>();
            _AS = new AuthService(_MkLogServ.Object, _MkPWHash.Object);
        }
        [Test]
        public async Task Login_ExistingPW_UserName()
        {
            //Arrange
            string ExpectedUsername = "testusername";
            string ExpectedPassword = "testpassword";
            _MkLogServ.Setup(f => f.GetByUsername(ExpectedUsername)).ReturnsAsync(new Account()
            {
                WhichUser = new User() { Username = ExpectedUsername }
            });
            _MkPWHash.Setup(f => f.VerifyHashedPassword(It.IsAny<string>(), ExpectedPassword)).Returns(PasswordVerificationResult.Success);

            //Act
            Account account = await _AS.Login(ExpectedUsername, ExpectedPassword);

            //Assert
            string ActualUsername = account.WhichUser.Username;
            Assert.AreEqual(ExpectedUsername, ActualUsername);
        }
        [Test]
        public void Login_IncorrectPW_UserName()
        {
            //Arrange
            string ExpectedUsername = "testusername";
            string ExpectedPassword = "testpassword";
            _MkLogServ.Setup(f => f.GetByUsername(ExpectedUsername)).ReturnsAsync(new Account()
            {
                WhichUser = new User() { Username = ExpectedUsername }
            });
            _MkPWHash.Setup(f => f.VerifyHashedPassword(It.IsAny<string>(), ExpectedPassword)).Returns(PasswordVerificationResult.Failed);
            AuthService AS = new AuthService(_MkLogServ.Object, _MkPWHash.Object);

            //Act
            InvalidPasswordX IPX = Assert.ThrowsAsync<InvalidPasswordX>(() => _AS.Login(ExpectedUsername, ExpectedPassword));

            //Assert
            string ActualUsername = IPX.Username;
            Assert.AreEqual(ExpectedUsername, ActualUsername);
        }
    }
}
