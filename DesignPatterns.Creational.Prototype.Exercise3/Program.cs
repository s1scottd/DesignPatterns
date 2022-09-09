using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace DesignPatterns.Creational.Prototype.Exercise3
{
	public class Point
	{
		public int X, Y;

		public override string ToString()
		{
			return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
		}
	}

	public class Line
	{
		public Point Start, End;

		public Line DeepCopy()
		{
			return new Line
			{
				Start = new Point()
				{
					X = this.Start.X,
					Y = this.Start.Y
				},
				End = new Point()
				{
					X = this.End.X,
					Y = this.End.Y
				}
			};
		}

		public override string ToString()
		{
			return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var line1 = new Line
			{
				Start = new Point()
				{
					X = 0,
					Y = 0
				},
				End = new Point()
				{
					X =	1,
					Y = 1
				}
			};

			var line2 = line1.DeepCopy();
			line2.Start.X = 10;

			WriteLine($"line1: {line1}");
			WriteLine($"line2: {line2}");
		}
	}
}