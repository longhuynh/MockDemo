﻿using System;
using Demo.Moq.Code.Demo06;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo06
{
    [TestFixture]
    public class CustomerServiceTests
    {
        //verify that specific parameter values are passed to the mock object
        [Test]
        public void Create_FullNameFromFirstAndLastName_ShouldBeCreated()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto
            {
                FirstName = "Bob",
                LastName = "Builder"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockFullNameBuilder = new Mock<ICustomerFullNameBuilder>();

            mockFullNameBuilder.Setup(
                x => x.From(It.IsAny<string>(), It.IsAny<string>()));

            var customerService = new CustomerService(
                mockCustomerRepository.Object, mockFullNameBuilder.Object);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            mockFullNameBuilder.Verify(x => x.From(
                It.Is<string>(
                    fn => fn.Equals(customerToCreateDto.FirstName,
                        StringComparison.InvariantCultureIgnoreCase)),
                It.Is<string>(
                    fn => fn.Equals(customerToCreateDto.LastName,
                        StringComparison.InvariantCultureIgnoreCase))));
        }
    }
}