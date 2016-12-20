using Demo.Moq.Code.Demo09;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo09
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheLocalTimezone_ShouldBeSet()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            var customerService = new CustomerService(
                mockCustomerRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.VerifySet(
                x => x.LocalTimeZone = It.IsAny<string>());
        }
    }
}