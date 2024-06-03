using LM555DependenciesCalculator;

namespace LM555DependenciesCalculatorTests
{
	public class CalculatorTests
	{
		Calculator calculator;

		[SetUp]
		public void Setup()
		{
			calculator = new Calculator();
		}

		[Test]
		public void Calculate_ReturnTimerResultType()
		{
			var calculation = calculator.Calculate(1f, 1f, 0.1f);
			Assert.That(calculation.GetType(), Is.EqualTo(typeof(TimerResult)));
		}

		[Test]
		[TestCase(-1000f)]
		[TestCase(-10f)]
		[TestCase(-1f)]
		[TestCase(-0.1f)]
		[TestCase(-0.001f)]
		public void Calculate_NegativeCapacitanceValue_ThrowsError(float negativeCapacitance)
		{
			Assert.Throws<ArgumentException>(() => calculator.Calculate(1f, 1f, negativeCapacitance), "Capacitance Must Be Higher Than Zero");
		}

		[Test]
		public void Calculate_ZeroCapacitanceValue_ThrowsError()
		{
			Assert.Throws<ArgumentException>(() => calculator.Calculate(1f, 1f, 0f), "Capacitance Must Be Higher Than Zero");
		}

		[Test]
		[TestCase(1f, 1.386f, 0.693f, 480f)]
		public void Calculate_CalculationOnCapacitanceVariation_ReturnTimerResult(
				float capacitance,
				float expectedTimeHigh,
				float expectedTimeLow,
				float expectedFrequency
			)
		{
			var calculation = calculator.Calculate(1f, 1f, capacitance);

			Assert.AreEqual(calculation.timeHigh, expectedTimeHigh, 0.001f);
			Assert.AreEqual(calculation.timeLow, expectedTimeLow, 0.001f);
			Assert.AreEqual(calculation.frequency, expectedFrequency, 0.001f);
		}
	}
}