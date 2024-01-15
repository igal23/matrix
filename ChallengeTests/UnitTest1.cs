using Challenge;
using Xunit;
using Assert = Xunit.Assert;

namespace ChallengeTests
{
    public class WordFinderTests
    {
        private readonly WordFinder wordFinder;

        public WordFinderTests()
        {
            IEnumerable<string> matrix = new List<string>
            {
                "waya",
                "ayaw",
                "yaaa",
                "aaay",
                "waxax"
            };

            wordFinder = new WordFinder(matrix);
        }

        [Fact]
        public void Find_ShouldReturnTop10Words_WhenValidWordstream()
        {
            IEnumerable<string> wordStream = new List<string>
            {
                "way",
                "wax",
                "invalid",
            };

            var result = wordFinder.Find(wordStream);

            Assert.Equal(new[] { "way", "wax" }, result);
        }

        [Fact]
        public void Find_ShouldReturnEmptyList_WhenEmptyWordstream()
        {
            IEnumerable<string> wordStream = new List<string>();

            var result = wordFinder.Find(wordStream);

            Assert.Empty(result);
        }

        [Fact]
        public void Find_ShouldReturnEmptyList_WhenNoWordsFound()
        {
            IEnumerable<string> wordStream = new List<string>
            {
                "nothing",
                "test",
                "foo",
            };

            var result = wordFinder.Find(wordStream);

            Assert.Empty(result);
        }
    }
}