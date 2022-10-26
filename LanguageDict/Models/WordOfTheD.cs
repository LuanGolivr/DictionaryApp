

namespace LanguageDict.Models
{
    public class WordOfTheD
    {
        Root _dictData { get; set; }
        public string Word { get; set; }
        public string Meanings { get; set; }
        public string Synonimus { get; set; }
        public string Antonyms { get; set; }

        public WordOfTheD(Root dictData = null)
        {
            _dictData = dictData;
            Word = _dictData.word;
            getMeanings(_dictData.meanings);
            getSynonimus(_dictData.meanings);
            getAntonyms(_dictData.meanings);
            
        }


        private void getMeanings(List<Meaning> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].definitions.Count; j++)
                {
                    result += $"{list[i].definitions[j].definition}";
                    result += "\n";
                }
                Meanings += result;
                Meanings += "\n";
            }
        }

        private void getSynonimus(List<Meaning> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].synonyms.Count; j++)
                {
                    result += $"{list[i].synonyms[j]}";
                    result += "\n";
                }
                Synonimus += result;
                Synonimus += "\n";
            }

        }

        private void getAntonyms(List<Meaning> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string result = "";
                for(int j = 0; j < list[i].antonyms.Count; j++)
                {
                    result += $"{list[i].antonyms[j]}";
                    result += "\n";
                }

                Antonyms += result;
                Antonyms += "\n";
            }
        }
    }

}
