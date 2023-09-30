namespace Matrix
{
	public class Node : INode
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public int Value { get; set; }
		public Node Next { get; set; }
		public Node(int row, int column, int value)
		{
			Row = row;
			Column = column;
			Value = value;
			Next = null;
		}
	}
}
