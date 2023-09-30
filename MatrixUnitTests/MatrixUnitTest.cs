using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixUnitTests
{
	[TestClass]
	public class MatrixUnitTest
	{
		[TestMethod]
		public void Matrix_Equals_WithEqualMatrices_ReturnsTrue()
		{
			// Arrange
			IMatrix matrix1 = new MatrixImplementation(2, 3);
			IMatrix matrix2 = new MatrixImplementation(2, 3);

			// Act
			bool areEqual = matrix1.Equals(matrix2);

			// Assert
			Assert.IsTrue(areEqual, "Matrix Equals повинен повертати true для рівних матриць.");
		}

		[TestMethod]
		public void Matrix_Constructor_WithValidInputArray_CreatesMatrixWithCorrectValues()
		{
			// Arrange
			int[,] data =
			{{ 1, 0, 2 },
			{ 0, 3, 0 }};

			// Act
			MatrixImplementation matrix = new MatrixImplementation(data);

			// Assert
			Assert.AreEqual(2, matrix.Rows, "Матриця повинна мати 2 рядки.");
			Assert.AreEqual(3, matrix.Columns, "Матриця повинна мати 3 стовпці.");
			Assert.AreEqual(1, matrix.GetValueAt(0, 0), "Значення матриці на позиції (0, 0) повинно бути 1.");
			Assert.AreEqual(2, matrix.GetValueAt(0, 2), "Значення матриці на позиції (0, 2) повинно бути 2.");
			Assert.AreEqual(3, matrix.GetValueAt(1, 1), "Значення матриці на позиції (1, 1) повинно бути 3.");
		}

		[TestMethod]
		public void Matrix_GetHashCode_ReturnsHashCode()
		{
			// Arrange
			IMatrix matrix = new MatrixImplementation(2, 3);

			// Act
			int hashCode = matrix.GetHashCode();

			// Assert
			Assert.IsNotNull(hashCode, "Matrix GetHashCode повинен повертати дійсний хеш-код.");
		}

		[TestMethod]
		public void Matrix_GetValueAt_WithSetValue_ReturnsCorrectValue()
		{
			// Arrange
			IMatrix matrix = new MatrixImplementation(2, 3);
			matrix.SetValueAt(0, 1, 42);

			// Act
			int value = matrix.GetValueAt(0, 1);

			// Assert
			Assert.AreEqual(42, value, "Matrix GetValueAt повинен повертати правильне значення після встановлення його.");
		}

		[TestMethod]
		public void Matrix_MultiplyByConstant_WithValidInput_MultipliesValuesByConstant()
		{
			// Arrange

			int constant = 2;
			int[,] data =
			{{ 1, 2, 3 },
			{ 4, 5, 6 }};
			IMatrix matrix = new MatrixImplementation(data);

			// Act 
			matrix.MultiplyByConstant(constant);

			// Assert
			// Перевіряємо, що значення були правильно помножені
			Assert.AreEqual(2, matrix.GetValueAt(0, 0), "Значення матриці повинні бути правильно помножені.");
			Assert.AreEqual(4, matrix.GetValueAt(0, 1), "Значення матриці повинні бути правильно помножені.");
			Assert.AreEqual(6, matrix.GetValueAt(0, 2), "Значення матриці повинні бути правильно помножені.");
			Assert.AreEqual(8, matrix.GetValueAt(1, 0), "Значення матриці повинні бути правильно помножені.");
			Assert.AreEqual(10, matrix.GetValueAt(1, 1), "Значення матриці повинні бути правильно помножені.");
			Assert.AreEqual(12, matrix.GetValueAt(1, 2), "Значення матриці повинні бути правильно помножені.");
		}

		[TestMethod]
		public void Matrix_SetValueAt_WithSetValue_SetsValueCorrectly()
		{
			// Arrange
			IMatrix matrix = new MatrixImplementation(2, 3);

			// Act
			matrix.SetValueAt(1, 2, 42);

			// Assert
			Assert.AreEqual(42, matrix.GetValueAt(1, 2), "Matrix SetValueAt повинен встановлювати значення правильно.");
		}

		[TestMethod]
		public void Matrix_ToString_ReturnsStringRepresentation()
		{
			// Arrange
			IMatrix matrix = new MatrixImplementation(2, 3);

			// Act
			string str = matrix.ToString();

			// Assert
			Assert.IsNotNull(str, "Matrix ToString повинен повертати не-null рядкове представлення.");
		}

		[TestMethod]
		public void Matrix_Transpose_WithSetValue_TransposesMatrix()
		{
			// Arrange
			IMatrix matrix = new MatrixImplementation(2, 3);
			matrix.SetValueAt(0, 1, 42);

			// Act
			matrix.Transpose();

			// Assert
			Assert.AreEqual(42, matrix.GetValueAt(1, 0), "Matrix Transpose повинен правильно транспонувати значення.");
		}
	}
}
