using Challenge;

IEnumerable<string> matrix = new List<string>
{
    "waya",
    "ayaw",
    "yaaa",
    "aaay",
    "waax"
};

IWordFinder wordFinder = new WordFinder(matrix);

// Example word stream
IEnumerable<string> wordStream = new List<string>
{
    "way",
    "ya",
    "invalid",
};

// Find the top 10 most repeated words in the matrix
IEnumerable<string> result = wordFinder.Find(wordStream);

// Display the result
Console.WriteLine("Top 10 most repeated words:");
foreach (string word in result)
{
    Console.WriteLine(word);
}

Console.Read();