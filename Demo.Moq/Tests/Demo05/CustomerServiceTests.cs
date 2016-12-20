using System.Collections.Generic;
using Demo.Moq.Code.Demo05;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo05
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_EachCustomer_ShouldBeAssignedAnId()
        {
            //Arrange
            var listOfCustomersToCreate = new List<CustomerToCreateDto>
            {
                new CustomerToCreateDto(),
                new CustomerToCreateDto()
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockIdFactory = new Mock<IIdFactory>();

            var i = 1;
            mockIdFactory.Setup(x => x.Create())
                .Returns(() => i)
                .Callback(() => i++);

            var customerService = new CustomerService(
                mockCustomerRepository.Object, mockIdFactory.Object);

            //Act
            customerService.Create(listOfCustomersToCreate);

            //Assert
            mockIdFactory.Verify(x => x.Create(), Times.AtLeastOnce());
        }
    }
}