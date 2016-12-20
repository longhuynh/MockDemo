using Demo.Moq.Code.Demo11;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo11
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheWorkStationId_ShouldBeRetrieved()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockApplicationSettings.Setup(
                x => x.SystemConfiguration.AuditingInformation.WorkstationId)
                .Returns(123);

            var customerService = new CustomerService(mockCustomerRepository.Object, mockApplicationSettings.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockApplicationSettings.VerifyGet(
                x => x.SystemConfiguration.AuditingInformation.WorkstationId);
        }
    }
}