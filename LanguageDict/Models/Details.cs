using System.Collections.ObjectModel;

namespace LanguageDict.Models
{
    class Details
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Meanings { get; set; }
        public string Synonimus { get; set; }
        public string Antonyms { get; set; }
        public string Examples { get; set; }

        public Details(Words word = null)
        {
            Word = word.Word;
            Translation = word.Translation;
            GetMeanings(word.Meanings);
            GetSynonimus(word.Synonimus);
            GetAntonymus(word.Antonyms);
            GetExamples(word.Examples);
        }

        private void GetMeanings(ObservableCollection<string> meaning)
        {
            string result = string.Empty;
            for(int i = 0; i < meaning.Count; i++)
            {
                result += meaning[i];
                result += "\n";
            }
            Meanings = result;
        }

        private void GetSynonimus(ObservableCollection<string> synonimus)
        {
            string result = string.Empty;
            for(int i = 0; i < synonimus.Count; i++)
            {
                result += synonimus[i];
                result += "\n";
            }
            Synonimus = result;
        }

        private void GetAntonymus(ObservableCollection<string> antonymus)
        {
            string result = string.Empty;
            for(int i = 0; i < antonymus.Count; i++)
            {
                result += antonymus[i];
                result += "\n";
            }
            Antonyms = result;
        }

        private void GetExamples(ObservableCollection<string> examples)
        {
            string result = string.Empty;
            for(int i = 0; i < examples.Count; i++)
            {
                result += examples[i];
                result += "\n";
            }
            Examples = result;
        }
    }
}
