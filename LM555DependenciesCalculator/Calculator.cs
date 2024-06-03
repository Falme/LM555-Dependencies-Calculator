using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM555DependenciesCalculator
{
	public class Calculator
	{
		public void FindPossibleTimerCombinationInMilliseconds(float targetMilliseconds, float delta)
		{
			for (int resistorAIndex = 0; resistorAIndex < Consts.resistors.Length; resistorAIndex++)
			{
				for (int resistorBIndex = 0; resistorBIndex < Consts.resistors.Length; resistorBIndex++)
				{
					for (int capacitorIndex = 0; capacitorIndex < Consts.capacitors.Length; capacitorIndex++)
					{
						TimerResult result =
							Calculate(
								Consts.resistors[resistorAIndex],
								Consts.resistors[resistorBIndex],
								Consts.capacitors[capacitorIndex]
								);

						float milliseconds = result.timeHigh+result.timeLow;

						if(milliseconds <= (targetMilliseconds+delta) && milliseconds >= (targetMilliseconds-delta))
						{
							Console.WriteLine($"Found = R1:{Consts.resistors[resistorAIndex]}kOhms, R2:{Consts.resistors[resistorBIndex]}kOhms, C:{Consts.capacitors[capacitorIndex]}uF ; Value In Milliseconds:{milliseconds}");
						}
					}
				}
			}
		}


		public void FindPossibleTimerCombinationInHertz(float targetHertz, float delta)
		{
			for (int resistorAIndex = 0; resistorAIndex < Consts.resistors.Length; resistorAIndex++)
			{
				for (int resistorBIndex = 0; resistorBIndex < Consts.resistors.Length; resistorBIndex++)
				{
					for (int capacitorIndex = 0; capacitorIndex < Consts.capacitors.Length; capacitorIndex++)
					{
						TimerResult result =
							Calculate(
								Consts.resistors[resistorAIndex],
								Consts.resistors[resistorBIndex],
								Consts.capacitors[capacitorIndex]
								);

						if (result.frequency <= (targetHertz + delta) && result.frequency >= (targetHertz - delta))
						{
							Console.WriteLine($"Found = R1:{Consts.resistors[resistorAIndex]}kOhms, R2:{Consts.resistors[resistorBIndex]}kOhms, C:{Consts.capacitors[capacitorIndex]}uF ; Value In Hertz:{result.frequency}");
						}
					}
				}
			}
		}

		public TimerResult Calculate(float resistanceA, float resistanceB, float capacitance)
		{
			if(capacitance <= 0f) {  throw new ArgumentException("Capacitance Must Be Higher Than Zero"); }

			float timeHigh = 0.693f * (resistanceA + resistanceB) * capacitance;
			float timeLow = 0.693f * resistanceB * capacitance;
			float frequency = 1.44f/( ( resistanceA + (2*resistanceB) ) * capacitance );

			return new TimerResult
			{
				timeHigh = timeHigh,
				timeLow = timeLow,
				frequency = frequency*1000
			};
		}

	}

	public struct TimerResult
	{
		public float timeHigh;
		public float timeLow;
		public float frequency;
	}
}
