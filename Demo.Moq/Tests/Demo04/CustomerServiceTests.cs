using Demo.Moq.Code.Demo04;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo04
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_TheCustomer_ShouldBePersisted()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();

            var mailingAddress = new MailingAddress {Country = "Canada"};
            mockMailingAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress))
                .Returns(true);

            var customerService = new CustomerService(
                mockCustomerRepository.Object, mockMailingAddressFactory.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }
    }
}