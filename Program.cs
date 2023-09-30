using System;

namespace Matrix
{
	public class Program
	{
		static void Main()
		{
			// Створення об'єкту класу MatrixImplementation
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
			MatrixImplementation matrix2 = new MatrixImplementation(a);
			MatrixImplementation matrix3= new MatrixImplementation(2,3);
			// Виклик методу для введення матриці з консолі
			matrix3.InputMatrixFromConsole();
			// Виклик методу для виведення матриці на консоль
			Console.WriteLine(matrix1);
			Console.WriteLine(matrix2);
			Console.WriteLine(matrix3);
			Console.ReadLine();
		}
	}
}
