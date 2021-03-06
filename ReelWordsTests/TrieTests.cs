
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class TrieTests
    {
        private const string AWESOME_CO = "pierplay";

        //Prob should find way to run dictionary insertion once, still pretty fast though
        [Fact]
        public void TrieInsertTest()
        {
            Trie trie = new Trie();
            trie.Insert(AWESOME_CO);
            Assert.True(trie.Search(AWESOME_CO));
        }

        [Fact]
        public void TrieDeleteTest()
        {
            Trie trie = new Trie();
            trie.Insert(AWESOME_CO);
            Assert.True(trie.Search(AWESOME_CO));
            trie.Delete(AWESOME_CO);
            Assert.False(trie.Search(AWESOME_CO));
        }

        [Fact]
        public void TrieDeleteOnlyOneOutOfMany()
        {
            Trie trie = new Trie();
            trie.Insert("help");
            trie.Insert("helping");
            trie.Insert("helpless");
            trie.Delete("helping");
            Assert.True(trie.Search("help"));
            Assert.True(trie.Search("helpless"));
        }
    }
}