using Demo.Moq.Code.Demo18;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo18
{
    [TestFixture]
    public class CustomerNameFormatterTests
    {
        [Test]
        public void Create_AllBadWords_ShouldBeScrubbed()
        {
            //Arrange
            var mockCustomerNameFormatter = new Mock<CustomerNameFormatter>();

            mockCustomerNameFormatter.Protected()
                .Setup<string>("ParseBadWordsFrom", ItExpr.IsAny<string>())
                .Returns("asdf")
                .Verifiable();

            //Act
            mockCustomerNameFormatter.Object.From(new Customer());

            //Assert
            mockCustomerNameFormatter.Verify();
        }
    }
}