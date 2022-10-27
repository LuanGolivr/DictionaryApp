

namespace LanguageDict.Models
{
    public class WordOfTheD
    {
        public string Word { get; set; }
        public string Meanings { get; set; }
        public string Synonimus { get; set; }
        public string Antonyms { get; set; }

        public WordOfTheD(Root dictData = null)
        {
            Word = dictData.word;
            getMeanings(dictData.meanings);
            getSynonimus(dictData.meanings);
            getAntonyms(dictData.meanings);
            
        }


        private void getMeanings(List<Meaning> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].definitions.Count; j++)
                {
                    if (list[i].definitions[j].definition != "" && list[i].definitions[j].definition != null)
                    {
                        result += $"{list[i].definitions[j].definition}";
                        result += "\n\n";
                    }
                }
                if(result != null && result != "")
                {
                    Meanings += $"{result}";
                    Meanings += "\n\n";
                }
                
            }
        }

        private void getSynonimus(List<Meaning> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].synonyms.Count; j++)
                {
                    if (list[i].synonyms[j] != "" && list[i].synonyms[j] != null)
                    {
                        result += $"{list[i].synonyms[j]}";
                        result += "\n";
                    }
                    
                }

                if(result != null && result != "")
                {
                    Synonimus += $"{result}";
                    Synonimus += "\n";
                }
                
            }

        }

        private void getAntonyms(List<Meaning> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].antonyms.Count; j++)
                {
                    if (list[i].antonyms[j] != "" && list[i].antonyms[j] != null)
                    {
                        result += $"{list[i].antonyms[j]}";
                        result += "\n";
                    }
                    
                }

                if(result != null && result != "")
                {
                    Antonyms += $"{result}";
                    Antonyms += "\n";
                }
                
            }
        }
    }

}
