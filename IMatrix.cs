namespace Matrix
{
	public interface IMatrix
	{
		int Rows { get; }
		int Columns { get; }
		int GetValueAt(int row, int col);
		void SetValueAt(int row, int col, int value);
		void Add(MatrixImplementation other);
		void MultiplyByConstant(int constant);
		void Transpose();
		MatrixImplementation Multiply(MatrixImplementation other);
	}
}
