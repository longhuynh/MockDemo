using Demo.Moq.Code.Demo10;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo10
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheWorkStationId_ShouldBeUsed()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockApplicationSettings.Setup(x => x.WorkstationId).Returns(123);

            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockApplicationSettings.VerifyGet(x => x.WorkstationId);
        }
    }
}