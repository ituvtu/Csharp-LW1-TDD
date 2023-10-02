using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Matrix
{
	[TestClass]
	public class MatrixUnitTest
	{
		[TestMethod]
		public void MatrixEqualityTest()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			MatrixImplementation matrix2 = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix1.SetValueAt(i, j, i * 3 + j);
					matrix2.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			bool areEqual = matrix1.Equals(matrix2);

			// Assert
			Assert.IsTrue(areEqual);
		}

		[TestMethod]
		public void MatrixInequalityTest()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			MatrixImplementation matrix2 = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix1.SetValueAt(i, j, i * 3 + j);
					matrix2.SetValueAt(i, j, (i * 3 + j) + 1);
				}
			}

			// Act
			bool areEqual = matrix1.Equals(matrix2);

			// Assert
			Assert.IsFalse(areEqual);
		}

		[TestMethod]
		public void MatrixHashCodeTest()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			int hashCode = matrix.GetHashCode();

			// Assert
			Assert.IsNotNull(hashCode);
		}

		[TestMethod]
		public void GetValueAtTest()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			matrix.SetValueAt(1, 2, 42);

			// Act
			int value = matrix.GetValueAt(1, 2);

			// Assert
			Assert.AreEqual(42, value);
		}

		[TestMethod]
		public void SetValueAtValidIndicesSetsCorrectValue()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange & Act
			matrix.SetValueAt(0, 0, 7);

			// Assert
			Assert.AreEqual(7, matrix.GetValueAt(0, 0));
		}

		[TestMethod]
		public void SetValueAtInvalidIndicesThrowsIndexOutOfRangeException()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange & Act
			void action() => matrix.SetValueAt(3, 4, 7); // Невалідні індекси

			// Assert
			Assert.ThrowsException<IndexOutOfRangeException>(action);
		}


		[TestMethod]
		public void MatrixToStringTest()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			string matrixString = matrix.ToString();

			// Assert
			string expected = "0 1 2 \r\n3 4 5 \r\n";
			Assert.AreEqual(expected, matrixString);
		}

		[TestMethod]
		public void MatrixInputFromConsoleTest()
		{
			// Arrange
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Симулюємо введення кожного значення окремо
			var inputStream = new MemoryStream();
			var streamWriter = new StreamWriter(inputStream);
			var streamReader = new StreamReader(inputStream);
			Console.SetIn(streamReader);

			// Симулюємо введення значень 1, 2, 3, 4, 5, 6
			streamWriter.WriteLine("1");
			streamWriter.WriteLine("2");
			streamWriter.WriteLine("0");
			streamWriter.WriteLine("4");
			streamWriter.WriteLine("5");
			streamWriter.WriteLine("6");
			streamWriter.Flush();
			inputStream.Seek(0, SeekOrigin.Begin);

			// Act
			matrix.InputMatrixFromConsole();

			// Assert
			Assert.AreEqual(1, matrix.GetValueAt(0, 0));
			Assert.AreEqual(2, matrix.GetValueAt(0, 1));
			Assert.AreEqual(0, matrix.GetValueAt(0, 2));
			Assert.AreEqual(4, matrix.GetValueAt(1, 0));
			Assert.AreEqual(5, matrix.GetValueAt(1, 1));
			Assert.AreEqual(6, matrix.GetValueAt(1, 2));
		}




		[TestMethod]
		public void MultiplyByConstantPositiveConstantMultipliesValues()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			matrix.MultiplyByConstant(2);

			// Assert
			Assert.AreEqual(0, matrix.GetValueAt(0, 0));
			Assert.AreEqual(2, matrix.GetValueAt(0, 1));
			Assert.AreEqual(4, matrix.GetValueAt(0, 2));
			Assert.AreEqual(6, matrix.GetValueAt(1, 0));
			Assert.AreEqual(8, matrix.GetValueAt(1, 1));
			Assert.AreEqual(10, matrix.GetValueAt(1, 2));
		}

		[TestMethod]
		public void MultiplyByConstantNegativeConstantMultipliesValues()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			matrix.MultiplyByConstant(-2);

			// Assert
			Assert.AreEqual(0, matrix.GetValueAt(0, 0));
			Assert.AreEqual(-2, matrix.GetValueAt(0, 1));
			Assert.AreEqual(-4, matrix.GetValueAt(0, 2));
			Assert.AreEqual(-6, matrix.GetValueAt(1, 0));
			Assert.AreEqual(-8, matrix.GetValueAt(1, 1));
			Assert.AreEqual(-10, matrix.GetValueAt(1, 2));
		}

		[TestMethod]
		public void MultiplyByConstantZeroConstantNoChanges()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			matrix.MultiplyByConstant(0);

			// Assert
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Assert.AreEqual(0, matrix.GetValueAt(i, j));
				}
			}
		}

		[TestMethod]
		public void TransposeValidMatrixTransposesCorrectly()
		{
			MatrixImplementation matrix = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix.SetValueAt(i, j, i * 3 + j);
				}
			}

			// Act
			matrix.Transpose();

			// Assert
			Assert.AreEqual(0, matrix.GetValueAt(0, 0));
			Assert.AreEqual(3, matrix.GetValueAt(0, 1));
			Assert.AreEqual(1, matrix.GetValueAt(1, 0));
			Assert.AreEqual(4, matrix.GetValueAt(1, 1));
			Assert.AreEqual(2, matrix.GetValueAt(2, 0));
			Assert.AreEqual(5, matrix.GetValueAt(2, 1));
		}

		[TestMethod]
		public void AddSameSizeMatricesAddsCorrectly()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			MatrixImplementation matrix2 = new MatrixImplementation(2, 3);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix1.SetValueAt(i, j, i * 3 + j);
					matrix2.SetValueAt(i, j, (i * 3 + j) * 2);
				}
			}

			// Act
			matrix1.Add(matrix2);

			// Assert
			Assert.AreEqual(0, matrix1.GetValueAt(0, 0));
			Assert.AreEqual(3, matrix1.GetValueAt(0, 1));
			Assert.AreEqual(6, matrix1.GetValueAt(0, 2));
			Assert.AreEqual(9, matrix1.GetValueAt(1, 0));
			Assert.AreEqual(12, matrix1.GetValueAt(1, 1));
			Assert.AreEqual(15, matrix1.GetValueAt(1, 2));
		}

		[TestMethod]
		public void AddDifferentSizeMatricesThrowsException()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			MatrixImplementation matrix2 = new MatrixImplementation(3, 2);

			// Arrange & Act
			Assert.ThrowsException<ArgumentException>(() => matrix1.Add(matrix2));
		}


		[TestMethod]
		public void MultiplyValidMatricesMultipliesCorrectly()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 3);
			MatrixImplementation matrix2 = new MatrixImplementation(3, 2);

			// Arrange
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix1.SetValueAt(i, j, i * 3 + j);
				}
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					matrix2.SetValueAt(i, j, i * 2 + j);
				}
			}

			// Act
			MatrixImplementation result = matrix1.Multiply(matrix2);

			// Assert
			Assert.AreEqual(10, result.GetValueAt(0, 0));
			Assert.AreEqual(13, result.GetValueAt(0, 1));
			Assert.AreEqual(28, result.GetValueAt(1, 0));
			Assert.AreEqual(40, result.GetValueAt(1, 1));
		}

		[TestMethod]
		public void MultiplyIncompatibleMatricesThrowsException()
		{
			MatrixImplementation matrix1 = new MatrixImplementation(2, 4);
			MatrixImplementation matrix2 = new MatrixImplementation(3, 4);

			// Arrange & Act
			Assert.ThrowsException<InvalidOperationException>(() => matrix1.Multiply(matrix2));
		}

	}
}
