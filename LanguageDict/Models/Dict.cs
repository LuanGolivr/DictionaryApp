using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace LanguageDict.Models
{
    public class Dict: ObservableObject
    {
        public string Native { get; set; }
        public string Target { get; set; }
        public string Description => "This is a word dictionary from the language " + Target.ToLower() + " to the language " + Native.ToLower() + ".";
        public Trie Trie { get; set; }
        public ObservableCollection<Words> allWorlds { get; set; } = new ObservableCollection<Words>();


        public Dict(string native = null, string target = null)
        {
            Native = native;
            Target = target;
            Trie = new Trie();
        }
    }
}
