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

        public Words(string word = null, string translation = null, Root dictData = null)
        {
            Word = word;
            Translation = translation;

            if(dictData != null)
            {
                distributeInfos(dictData.meanings);
            }
        }


        private void distributeInfos(List<Meaning> dictData)
        {
            for(int i = 0; i < dictData.Count; i++)
            {
                for (int j = 0; j < dictData[i].definitions.Count; j++)
                {
                    if (dictData[i].definitions[j].definition != "" && dictData[i].definitions[j].definition != null)
                    {
                        Meanings.Add(dictData[i].definitions[j].definition);
                    }

                    if (dictData[i].definitions[j].example != "" && dictData[i].definitions[j].example != null)
                    {
                        Examples.Add(dictData[i].definitions[j].example);
                    }
                }

                for (int j = 0; j < dictData[i].synonyms.Count; j++)
                {
                    if (dictData[i].synonyms[j] != null && dictData[i].synonyms[j] != "")
                    {
                        Synonimus.Add(dictData[i].synonyms[j]);
                    }
                }

                for(int j = 0; j < dictData[i].antonyms.Count; j++)
                {
                    if (dictData[i].antonyms[j] != null && dictData[i].antonyms[j] != "")
                    {
                        Antonyms.Add(dictData[i].antonyms[j]);
                    }
                }

            }

        }



    }   
}
