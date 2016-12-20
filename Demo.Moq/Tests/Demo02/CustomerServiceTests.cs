using System.Collections.Generic;
using Demo.Moq.Code.Demo02;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo02
{
    [TestFixture]
    public class CustomerServiceTests
    {
        //shows how to verify that a method was called an explicit number of times
        [Test]
        public void Create_TheCustomerRepository_ShouldBeCalledOncePerCustomer()
        {
            //Arrange
            var listOfCustomerDtos = new List<CustomerToCreateDto>
            {
                new CustomerToCreateDto
                {
                    FirstName = "Sam",
                    LastName = "Sampson"
                },
                new CustomerToCreateDto
                {
                    FirstName = "Bob",
                    LastName = "Builder"
                },
                new CustomerToCreateDto
                {
                    FirstName = "Doug",
                    LastName = "Digger"
                }
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();

            var customerService = new CustomerService(mockCustomerRepository.Object);
            //Act
            customerService.Create(listOfCustomerDtos);

            //Assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()),
                Times.Exactly(3));
        }
    }
}