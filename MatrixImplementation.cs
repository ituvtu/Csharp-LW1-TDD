using System;
using System.Text;
namespace Matrix
{
	public class MatrixImplementation : IMatrix
	{
		private Node matrixData; // Поле, що буде використовуватись для представлення матриці

		public MatrixImplementation(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
			matrixData = null; // Початкова матриця пуста
		}
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			IMatrix otherMatrix = (IMatrix)obj;

			if (Rows != otherMatrix.Rows || Columns != otherMatrix.Columns)
			{
				return false;
			}

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					if (GetValueAt(i, j) != otherMatrix.GetValueAt(i, j))
					{
						return false;
					}
				}
			}

			return true;
		}
		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + Rows.GetHashCode();
				hash = hash * 23 + Columns.GetHashCode();

				for (int i = 0; i < Rows; i++)
				{
					for (int j = 0; j < Columns; j++)
					{
						hash = hash * 23 + GetValueAt(i, j).GetHashCode();
					}
				}

				return hash;
			}
		}

		public MatrixImplementation(int[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data), "Input array is null.");
			}

			int rows = data.GetLength(0);
			int columns = data.GetLength(1);

			Rows = rows;
			Columns = columns;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					int value = data[i, j];
					if (value != 0)
					{
						SetValueAt(i, j, value);
					}
				}
			}

		}

		public int Rows { get; private set; }
		public int Columns { get; private set; }

		// Отримати значення елементу матриці за його рядком і стовпцем
		public int GetValueAt(int row, int col)
		{
			if (matrixData != null)
			{
				Node node = FindNode(row, col);
				if (node != null)
				{
					return node.Value;
				}
			}
			return 0; // Повертаємо 0 для нульових значень або якщо значення не знайдено.
		}

		// Встановити значення елементу матриці за його рядком і стовпцем
		public void SetValueAt(int row, int col, int value)
		{
			if (matrixData == null)
			{
				matrixData = new Node(row, col, value);
			}
			else
			{
				Node node = FindNode(row, col);
				if (node != null)
				{
					node.Value = value;
				}
				else
				{
					Node newNode = new Node(row, col, value)
					{
						Next = matrixData
					};
					matrixData = newNode;
				}
			}
		}
		// Метод для виведення матриці на консоль
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					sb.Append(GetValueAt(i, j) + " ");
				}
				sb.AppendLine(); // Перехід на новий рядок для виводу наступного рядка матриці
			}

			return sb.ToString();
		}


		// Метод для введення значень із консолі
		public void InputMatrixFromConsole()
		{
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					Console.Write($"Введіть значення для рядка {i + 1}, стовпця {j + 1}: ");
					int value = int.Parse(Console.ReadLine());
					this.SetValueAt(i, j, value);
				}
			}
		}


		// Помножити всі елементи матриці на константу
		public void MultiplyByConstant(int constant)
		{
			if (matrixData != null)
			{
				Node currentNode = matrixData;
				while (currentNode != null)
				{
					currentNode.Value *= constant;
					currentNode = currentNode.Next;
				}
			}
		}

		// Транспонувати матрицю
		public void Transpose()
		{
			if (matrixData != null)
			{
				int newRows = Columns;
				int newColumns = Rows;
				Node newMatrixData = null;

				Node currentNode = matrixData;
				while (currentNode != null)
				{
					Node nextNode = currentNode.Next;
					int newRow = currentNode.Column; // Перевертаємо рядок і стовпець
					int newCol = currentNode.Row;
					int value = currentNode.Value;

					Node newNode = new Node(newRow, newCol, value)
					{
						Next = newMatrixData
					};
					newMatrixData = newNode;

					currentNode = nextNode;
				}

				Rows = newRows;
				Columns = newColumns;
				matrixData = newMatrixData;
			}
		}

		// Додати іншу матрицю до поточної
		public void Add(MatrixImplementation other)
		{
			if (Rows != other.Rows || Columns != other.Columns)
			{
				throw new ArgumentException("Матрицi мають рiзну розмiрність i не можуть бути доданi.");
			}

			// Створюємо нову матрицю для зберігання суми
			MatrixImplementation result = new MatrixImplementation(Rows, Columns);

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					int value1 = this.GetValueAt(i, j);
					int value2 = other.GetValueAt(i, j);

					// Обчислюємо суму елементів та записуємо її в нову матрицю
					result.SetValueAt(i, j, value1 + value2);
				}
			}

			// Копіюємо результат в поточну матрицю
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					this.SetValueAt(i, j, result.GetValueAt(i, j));
				}
			}
		}

		// Перемножити матрицю на іншу матрицю
		public MatrixImplementation Multiply(MatrixImplementation other)
		{
			// Оператор множення матриць
			if (Columns != other.Rows)
			{
				throw new InvalidOperationException("Неможливо виконати множення матриць.");
			}

			MatrixImplementation result = new MatrixImplementation(Rows, other.Columns);

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < other.Columns; j++)
				{
					int value = 0;
					for (int k = 0; k < Columns; k++)
					{
						value += GetValueAt(i, k) * other.GetValueAt(k, j);
					}
					result.SetValueAt(i, j, value);
				}
			}
			return result;
		}

		private Node FindNode(int row, int col)
		{
			Node currentNode = matrixData;
			while (currentNode != null)
			{
				if (currentNode.Row == row && currentNode.Column == col)
				{
					return currentNode;
				}
				currentNode = currentNode.Next;
			}
			return null;
		}
	}

}