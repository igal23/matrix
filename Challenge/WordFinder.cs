namespace Challenge;

public class WordFinder : IWordFinder
{
    private readonly char[,] matrix;

    public WordFinder(IEnumerable<string> matrix)
    {
        this.matrix = CreateMatrix(matrix);
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

        foreach (string word in wordstream)
        {
            int count = CountWordOccurrences(word);
            if (count > 0)
            {
                wordOccurrences[word] = count;
            }
        }

        IOrderedEnumerable<KeyValuePair<string, int>> orderedWords = wordOccurrences.OrderByDescending(pair => pair.Value);

        return orderedWords.Take(10).Select(pair => pair.Key);
    }

    private int CountWordOccurrences(string word)
    {
        int occurrences = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - word.Length; col++)
            {
                if (CheckMatch(word, row, col, 0, 1))
                {
                    occurrences++;
                }
            }
        }

        for (int row = 0; row <= matrix.GetLength(0) - word.Length; row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (CheckMatch(word, row, col, 1, 0))
                {
                    occurrences++;
                }
            }
        }

        return occurrences;
    }

    private char[,] CreateMatrix(IEnumerable<string> matrix)
    {
        int rows = matrix.Count();
        int cols = matrix.First().Length;

        char[,] result = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            char[] rowChars = matrix.ElementAt(i).ToCharArray();
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = rowChars[j];
            }
        }

        return result;
    }

    private bool CheckMatch(string word, int startRow, int startCol, int rowIncrement, int colIncrement)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (matrix[startRow + i * rowIncrement, startCol + i * colIncrement] != word[i])
            {
                return false;
            }
        }
        return true;
    }
}
