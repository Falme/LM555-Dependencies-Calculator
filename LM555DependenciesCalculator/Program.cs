using LM555DependenciesCalculator;

// https://www.build-electronic-circuits.com/circuit-calculator-conversion/555-timer-calculator/

Console.WriteLine("Are you trying to find the Timer LM555 Combination in:");
Console.WriteLine("1 - Milliseconds");
Console.WriteLine("2 - Hertz");

string input = Console.ReadLine();

if (input == null || !(input.Equals("1") || input.Equals("2")))
{
	Console.WriteLine("Not a Valid Input, Closing;");
	Console.ReadKey();
	Environment.Exit(0);
}

Console.WriteLine("Write the Value you are looking for (only number and , ):");

float value = float.Parse(Console.ReadLine());

Console.WriteLine("Write the Offset for your value (N +/- Offset):");

float offset = float.Parse(Console.ReadLine());

Calculator calculator = new Calculator();

if(input.Equals("1"))
	calculator.FindPossibleTimerCombinationInMilliseconds(value, offset);
else
	calculator.FindPossibleTimerCombinationInHertz(value, offset);


Console.WriteLine("==================");

Console.WriteLine("Search Finished.");

Console.ReadKey();