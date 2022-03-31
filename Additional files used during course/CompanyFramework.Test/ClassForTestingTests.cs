using Xunit;

namespace CompanyFramework.Test
{
    public class ClassForTestingTests
    {
        [Fact]
        public void MethodForTesting_Execute_ReturnsTrue()
        {
            // Arrange
            var classForTesting = new ClassForTesting();

            // Act
            var result = classForTesting.MethodForTesting();

            // Assert
            Assert.True(result);
        }
    }
}