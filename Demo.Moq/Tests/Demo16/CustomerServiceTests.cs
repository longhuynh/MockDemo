using Demo.Moq.Code.Demo16;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo16
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheAddress_ShouldBeFormatted()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockAddressFormatterFactory =
                new Mock<IAddressFormatterFactory>
                {DefaultValue = DefaultValue.Mock};

            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockAddressFormatterFactory.Object);

            var addressFormatter = mockAddressFormatterFactory
                .Object.From(It.IsAny<string>());
            var mock = Mock.Get(addressFormatter);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mock.Verify(x => x.From(It.IsAny<CustomerToCreateDto>()));
        }
    }
}