
using System.Collections.ObjectModel;

namespace LanguageDict.Models
{
    partial class Dict
    {
        public string Native { get; set; }
        public string Target { get; set; }
        public string Image { get; set; }
        public string Description => "This is a word dictionary from the language " + Target + " to the language " + Native + ".";
        public Trie Trie { get; set; }
        public ObservableCollection<Words> allWorlds { get; set;}


        public Dict()
        {
            Trie = new Trie();
        }



    }
}
