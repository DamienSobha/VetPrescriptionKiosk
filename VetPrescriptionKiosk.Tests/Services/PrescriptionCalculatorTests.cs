using Xunit;
using VetPrescriptionKiosk.Services;
using VetPrescriptionKiosk.Models;

namespace VetPrescriptionKiosk.Tests.Services
{

    public class PrescriptionCalculatorTests
    {
        private readonly PrescriptionCalculator _calculator;

        public PrescriptionCalculatorTests()
        {
            _calculator = new PrescriptionCalculator();
        }

        [Fact]
        public void NormalDog_18Kg_Returns2Tablets()
        {
            var result = _calculator.Calculate(18, 0, DogCondition.Normal);

            Assert.Equal(2, result.WormerTablets);
            Assert.Equal(6.50m, result.TotalCost);
        }

        [Fact]
        public void Puppy_Returns1JuniorTablet()
        {
            var result = _calculator.Calculate(5, 8, DogCondition.Puppy);

            Assert.Equal(1, result.JuniorTablets);
            Assert.Equal(5.25m, result.TotalCost);
        }

        [Fact]
        public void NursingDog_12Kg_RoundsUpTo3Tablets()
        {
            var result = _calculator.Calculate(12, 0, DogCondition.Nursing);

            Assert.Equal(3, result.NursingTablets);
            Assert.Equal(1, result.TapewormDrops);
            Assert.Equal(16.00m, result.TotalCost);
        }

        [Fact]
        public void OverweightDog_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _calculator.Calculate(45, 0, DogCondition.Normal));
        }

        [Fact]
        public void InvalidWeight_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                _calculator.Calculate(0, 0, DogCondition.Normal));
        }
    }
}