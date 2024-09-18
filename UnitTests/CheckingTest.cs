using AccountingSystem;

namespace UnitTests
{
    [TestClass]
    public class CheckingTest
    {
        [TestMethod]
        public void Checking_AdjustBalance_Returns1000For500And500()
        {
            // Arrange
            var checking = new Checking(123456789, 500);

            // Act
            var result = checking.Balance + 500;

            // Assert
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void Checking_ApplyInterestRate_Returns50For1000And05()
        {
            // Arrange
            var checking = new Checking(123456789, 1000);

            // Act
            var result = checking.Balance * .05m;

            // Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Premium_ApplyInterestRate_Returns60For1000And06()
        {
            // Arrange
            var premium = new Premium(987654321, 1000);

            // Act
            var result = premium.Balance * .06m;

            // Assert
            Assert.AreEqual(60, result);
        }
    }
}