using System;

namespace ProgrammingAssignment1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome");
			Console.WriteLine("This application will calculate the distance between two points and the angle between those points.");
			Console.WriteLine("All you need is to input four coordinates. So let's get started!");
			Console.WriteLine();

			Console.WriteLine("Provide coorinate X of the first point");
			float point1X = float.Parse(Console.ReadLine());
			Console.WriteLine("Provide coorinate Y of the first point");
			float point1Y = float.Parse(Console.ReadLine());
			Console.WriteLine("Provide coorinate X of the second point");
			float point2X = float.Parse(Console.ReadLine());
			Console.WriteLine("Provide coorinate Y of the second point");
			float point2Y = float.Parse(Console.ReadLine());

			float deltaX = point1X - point2X;
			float deltaY = point1Y - point2Y;

			float hypotenuse = (float) Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

			float angleInRadians = (float) Math.Atan2(deltaY, deltaX);
			float angleInDegrees = angleInRadians * 180 / (float) Math.PI - 180;

			Console.WriteLine("The distance between the two points is: " + hypotenuse);
			Console.WriteLine("The angle between the two points (in degrees): " + angleInDegrees);
			Console.ReadLine();
		}
	}
}
