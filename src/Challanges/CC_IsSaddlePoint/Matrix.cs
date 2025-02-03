namespace CodeChallanges.Challanges.CC_IsSaddlePoint;

internal readonly record struct Matrix
{
	public Matrix(int[,] matrix)
	{
		var rows = matrix.GetLength(0);
		var arrs = new int[rows][];
		for(int i = 0; i < rows; i++)
		{
			arrs[i] = GetCollumnInRow(matrix, i);
		}
		_matrix = arrs;
		RowLength = rows;
		CollumnLength = matrix.GetLength(1);
	}
	private Matrix(int[][] matrix)
	{
		ArgumentNullException.ThrowIfNull(matrix, nameof(matrix));
		if(matrix.Length == 0)
		{
			throw new ArgumentException($"{nameof(matrix)} cannot be empty");
		}

		_matrix = matrix;
		RowLength = matrix.Length;
		CollumnLength = matrix[0].Length;
	}

	private readonly int[][] _matrix;

	public int RowLength { get; }
	public int CollumnLength { get; }

	public static Matrix Create(int rows, IEnumerable<int> defaultValues)
	{
		var matrix = new int[rows][];
		var setVal = defaultValues.ToArray();
		for(int i = 0; i < matrix.Length; i++)
		{
			matrix[i] = setVal;
		}
		return new(matrix);
	}
	public static Matrix Create(int rowLength, int collumnLength) => new(new int[rowLength, collumnLength]);

	public int[] this[int index]
	{
		get
		{
			if(index < 0 || index > RowLength)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}
			return _matrix[index];
		}
	}
	public int this[int rowIndex, int collIndex]
	{
		get
		{
			if(rowIndex < 0 || rowIndex > RowLength)
			{
				throw new ArgumentOutOfRangeException(nameof(rowIndex));
			}
			if(collIndex < 0 || collIndex > CollumnLength)
			{
				throw new ArgumentOutOfRangeException(nameof(collIndex));
			}
			return _matrix[rowIndex][collIndex];
		}
		set
		{
			if(rowIndex < 0 || rowIndex > RowLength)
			{
				throw new ArgumentOutOfRangeException(nameof(rowIndex));
			}
			if(collIndex < 0 || collIndex > CollumnLength)
			{
				throw new ArgumentOutOfRangeException(nameof(collIndex));
			}
			_matrix[rowIndex][collIndex] = value;
		}
	}

	private static int[] GetCollumnInRow(int[,] matrix, int row)
	{
		var colls = matrix.GetLength(1);
		var returnBuffer = new int[colls];
		for(int i = 0; i < colls; i++)
		{
			returnBuffer[i] = matrix[row, i];
		}
		return returnBuffer;
	}
}
