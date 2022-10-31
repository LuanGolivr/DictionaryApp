

namespace LanguageDict.Models
{
    public class TrieNode
    {
        public Dictionary<string, TrieNode> Children = new Dictionary<string, TrieNode>();

        public bool EndOfWord { get; set; }

        public TrieNode()
        {
            EndOfWord = false;
        }
    }

    public class Trie
    {

        public TrieNode rootNode = new TrieNode();

        public Trie(Dictionary<string, TrieNode> children = null)
        {
            if(children != null)
            {
                rootNode.Children = children;
            }
        }

        public bool AddWord(string word)
        {
            TrieNode current = rootNode;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                string letter = word[i].ToString();
                if (current.Children.ContainsKey(letter) == false )
                {
                    current.Children[letter] = new TrieNode();
                }
                current = current.Children[letter];
            }

            if (current.EndOfWord)
                return false;

            return current.EndOfWord = true;
            
        }

        public bool RemoveWord(string word)
        {
            TrieNode current = rootNode;
            word = word.ToLower();

            for(int i = 0; i <= word.Length; i++)
            {
                string letter = word[i].ToString();
                if (current.Children.ContainsKey(letter) == false)
                {
                    return false;
                }
                else
                {
                    if ((current.Children[letter].EndOfWord) && (i == word.Length - 1))
                    {
                        current.Children[letter].EndOfWord = false;
                        return true;
                    }

                    current = current.Children[letter];
                }
            }

            return false;
        }

        public bool SearchWord(string word)
        {
            TrieNode current = rootNode;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                string letter = word[i].ToString();

                if(current.Children.ContainsKey(letter) == false)
                {
                    return false;
                }

                current = current.Children[letter];
            }

            return current.EndOfWord;
        }

    }
}
