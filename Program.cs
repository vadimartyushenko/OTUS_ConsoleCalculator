using System;
using System.Text;

namespace ConsoleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{

			try
			{
				do
				{
					var x = GetNumber(1);
					var y = GetNumber(2);

					Console.WriteLine("Пожалуйста, выберите команду: +, -, *, /, max, min, mean");
					string cmd = Console.ReadLine();

					double result = GetResult(x, y, cmd);
					Console.WriteLine($"Результат - {result}");

					Console.WriteLine("Вы хотите продолжить? Нажми - Y (Да), N (Нет)");
					string next = Console.ReadLine();
					if (next != "Y")
						return;

				} while (true);

			}
			catch (DivideByZeroException)
			{
				Console.WriteLine("Ввод некорректен! Делить на 0 запрещено!");
				return;
			}
	
	}

		private static double GetResult(double x, double y, string cmd)
		{
			switch (cmd)
			{
				case "+": return x + y;
				case "-": return x - y;
				case "/":
				{
					if (y == 0)
						throw new DivideByZeroException();
					return x / y;
				}
				case "*": return x * y;
				case "max": return Max(x, y);
				case "min": return Min(x, y);
				case "mean": return Mean(x, y);
		    default: throw new Exception("Unknown command");
			}
		}

		static double GetNumber(int num)
		{
			var text = new StringBuilder();
			var strNumber = num switch
			{
				1 => "первое",
				2 => "второе",
				_ => " "
			};
			text.AppendFormat($"Пожалуйста, введите {strNumber} число");

			do
			{
				Console.WriteLine(text.ToString());

				var str = Console.ReadLine();
				if (double.TryParse(str, out double x))
				  return x;
				Console.WriteLine("Ввод некорретен! Попробуйте еще раз.");
			}
			while (true);
		}
		public static double Max(double a, double b) => a > b ? a : b;
		public static double Min(double a, double b) => a > b ? b : a;
		public static double Mean(double a, double b) => (a + b) / 2;

	}
}
