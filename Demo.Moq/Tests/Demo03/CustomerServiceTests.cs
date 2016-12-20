using Demo.Moq.Code.Demo03;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo03
{
    [TestFixture]
    public class CustomerServiceTests
    {
        //this shows how setting the return value will change the execution flow
        [Test]
        public void Create_IfAddressIsNotCreated_ShouldBeThrownAnException()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto
            {FirstName = "Bob", LastName = "Builder"};
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
                .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                .Returns(() => null);

            var customerService = new CustomerService(
                mockAddressBuilder.Object,
                mockCustomerRepository.Object);

            //Act
            //customerService.Create(customerToCreateDto);

            //Assert
            Assert.That(() => customerService.Create(customerToCreateDto),
                Throws.TypeOf<InvalidCustomerMailingAddressException>());
        }

        [Test]
        public void Create_IfTheAddressWasCreated_ShouldBeSaved()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto {FirstName = "Bob", LastName = "Builder"};
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
                .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                .Returns(() => new Address());

            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            mockCustomerRepository.Verify(y => y.Save(It.IsAny<Customer>()));
        }
    }
}