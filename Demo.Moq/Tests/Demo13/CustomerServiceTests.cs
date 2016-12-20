using Demo.Moq.Code.Demo13;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo13
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_AnEmail_ShouldBeSent()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMailingRepository = new Mock<IMailingRepository>();

            var customerService = new CustomerService(
                mockCustomerRepository.Object, mockMailingRepository.Object);

            //Act
            mockCustomerRepository.Raise(
                x => x.NotifySalesTeam += null,
                new NotifySalesTeamEventArgs("jim"));

            //Assert
            mockMailingRepository.Verify(
                x => x.NewCustomerMessage(It.IsAny<string>()));
        }
    }
}