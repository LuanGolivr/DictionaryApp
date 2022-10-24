using System.Collections.ObjectModel;

namespace LanguageDict.Models
{
    public class Words
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public ObservableCollection<string> Meanings { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Synonimus { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Antonyms { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Examples { get; set; } = new ObservableCollection<string>();

        /* Add news methods to work and deal with this properties */

    }   
}
