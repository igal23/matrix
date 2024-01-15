namespace Challenge;

public interface IWordFinder
{
    /// <summary>
    /// Finds the top 10 most repeated words from the given word stream in the character matrix.
    /// </summary>
    /// <param name="wordstream">The word stream to search in the matrix.</param>
    /// <returns>The top 10 most repeated words found in the matrix, ordered alphabetically.</returns>
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}
