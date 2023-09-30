namespace Matrix
{
	public interface INode
	{
		int Row { get; set; }
		int Column { get; set; }
		int Value { get; set; }
		Node Next { get; set; }
	}
}
