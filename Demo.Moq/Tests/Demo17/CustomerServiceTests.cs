using Demo.Moq.Code.Demo17;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo17
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheAddress_ShouldBeFormatted()
        {
            //Arrange
            var mockFactory = new MockRepository(MockBehavior.Loose)
            {DefaultValue = DefaultValue.Mock};
            var mockCustomerRepository =
                mockFactory.Create<ICustomerRepository>();
            var mockCustomerAddressFormatter =
                mockFactory.Create<ICustomerAddressFormatter>();

            mockCustomerAddressFormatter.Setup(
                x => x.For(It.IsAny<CustomerToCreateDto>()))
                .Returns(new Address());

            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockCustomerAddressFormatter.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockFactory.Verify();
        }
    }
}