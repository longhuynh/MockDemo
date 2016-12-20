using Demo.Moq.Code.Demo15;
using Moq;
using NUnit.Framework;

namespace Demo.Moq.Tests.Demo15
{
    [TestFixture]
    public class CustomerNameFormatterTests
    {
        [Test]
        public void Create_BadWordsFromTheFirstAndLastNames_ShouldBeStripped()
        {
            //Arrange
            var mockNameFormatter = new Mock<CustomerNameFormatter>();

            //Act
            mockNameFormatter.Object.From(new Customer("Bob", "SAPBuilder"));

            //Assert
            mockNameFormatter.Verify(
                x => x.ParseBadWordsFrom(It.IsAny<string>()),
                Times.Exactly(2));
        }
    }
}