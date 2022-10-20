namespace LanguageDict.Models
{
    internal class Words
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Meaning { get; set; }
        public List<string> Examples { get; set; }


        public bool addNewExample(string example)
        {
            for(int i = 0; i < Examples.Count; i++)
            {
                if (Examples[i] == example)
                {
                    return false;
                }
            }

            Examples.Add(example);
            return true;
        }

        public bool removeExample(string example)
        {
            for(int i = 0; i < Examples.Count; i++)
            {
                if (Examples[i] == example)
                {
                    Examples.RemoveAt(i);
                }
            }

            return true;
        }

        public void changeWord(string newWord)
        {
            Word = newWord;
        }

        public void changeTranslation(string newTranslation)
        {
            Translation = newTranslation;
        }

        public void changeMeaning(string newMeaning)
        {
            Meaning = newMeaning;
        }

    }   
}
