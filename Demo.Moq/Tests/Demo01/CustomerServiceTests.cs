using Demo.Moq.Code.Demo01;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo01
{
    [TestFixture]
    public class CustomerServiceTests
    {
        //shows the basic arrange, act, assert pattern
        //shows the simple verification of a method call
        [Test]
        public void Create_SaveMothod_ShoulbBeCalled()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(mockRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockRepository.VerifyAll();
        }
    }
}