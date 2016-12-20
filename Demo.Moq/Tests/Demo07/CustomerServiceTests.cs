using Demo.Moq.Code.Demo07;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo07
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void Create_SpecialSaveRoutine_ShouldBeUsed()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerStatusFactory = new Mock<ICustomerStatusFactory>();

            var customerToCreate = new CustomerToCreateDto
            {
                DesiredStatus = CustomerStatus.Bronze,
                FirstName = "Bob",
                LastName = "Builder"
            };

            mockCustomerStatusFactory.Setup(
                x => x.CreateFrom(
                    It.Is<CustomerToCreateDto>(
                        y => y.DesiredStatus == CustomerStatus.Platinum)))
                .Returns(CustomerStatus.Platinum);


            var customerService = new CustomerService(
                mockCustomerRepository.Object, mockCustomerStatusFactory.Object);

            //Act
            customerService.Create(customerToCreate);

            //Assert
            mockCustomerRepository.Verify(
                x => x.SaveSpecial(It.IsAny<Customer>()));
        }
    }
}