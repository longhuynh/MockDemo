using Demo.Moq.Code.Demo14;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo14
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheCustomer_ShouldBeSaved()
        {
            //Arrange
            var mockCustomerRepository =
                new Mock<ICustomerRepository>(MockBehavior.Strict);

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(
                mockCustomerRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.Verify();
        }
    }
}