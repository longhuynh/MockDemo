using Demo.Moq.Code.Demo08;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo08
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_AnException_ShouldBeRaised()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

            mockCustomerAddressFactory
                .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                .Throws<InvalidCustomerAddressException>();

            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockCustomerAddressFactory.Object);

            //Act
            //customerService.Create(new CustomerToCreateDto());

            //Assert
            Assert.That(() => customerService.Create(new CustomerToCreateDto()),
                Throws.TypeOf<CustomerCreationException>());
        }
    }
}