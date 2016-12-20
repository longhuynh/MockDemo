﻿using Demo.Moq.Code.Demo12;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo12
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

            mockApplicationSettings.SetupAllProperties();
            mockApplicationSettings.Object.WorkstationId = 2345;


            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockApplicationSettings.VerifyGet(x => x.WorkstationId);
        }
    }
}