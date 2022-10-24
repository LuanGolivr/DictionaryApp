using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LanguageDict.Models
{
    public class WordsP
    {
        public ObservableCollection<WordSelected> AllWordsSelected { get; set; } = new ObservableCollection<WordSelected>();
        private Main mainP = new Main();

        public WordsP()
        {
            
        }
    }

    public class WordSelected
    {
        public string word { get; set; }
        public string translate { get; set; }
        public string descr { get; set; }
        public string examples { get; set; }
    }


}
