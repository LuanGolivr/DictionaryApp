using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDict.Models
{
    partial class Dict
    {
        public string Native { get; set; }
        public string Target { get; set; }
        public string Image { get; set; }
        public string Description => "This is a word dictionary from the language " + Target + " to the language " + Native + ".";
        public Trie Trie { get; set; }

        public Dictionary<string, Dictionary<string, string>> words = new Dictionary<string, Dictionary<string, string>>(); 


        public Dict()
        {
            Trie = new Trie();
        }

    }
}
