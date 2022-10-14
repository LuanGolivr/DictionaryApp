using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LanguageDict.Views;
using Newtonsoft.Json;

namespace LanguageDict.Models
{
    internal class WordsP
    {
        public ObservableCollection<WordSelected> AllWordsSelected { get; set; } = new ObservableCollection<WordSelected>();
        private Mainpage mainP = new Mainpage();

        public WordsP()
        {
            loadCollection();
        }

        private void loadCollection()
        {
            using (StreamReader r = new StreamReader(mainP.selectedPath))
            {
                string json = r.ReadToEnd();
                List<Dict> items = JsonConvert.DeserializeObject<List<Dict>>(json);

                foreach (var item in items)
                {
                    foreach (var infos in item.words)
                    {
                        WordSelected nWord = new WordSelected();
                        nWord.word = infos.Key;
                        int cont = 0;
                        foreach(var info in infos.Value)
                        {
                            if(cont == 0)
                            {
                                nWord.translate = info.Value;
                            }
                            else if(cont == 1)
                            {
                                nWord.descr = info.Value;
                            }
                            else
                            {
                                nWord.examples = info.Value;
                            }
                            cont++;
                        }
                        AllWordsSelected.Add(nWord);
                    }
                    
                }
            }
        }


    }

    class WordSelected
    {
        public string word { get; set; }
        public string translate { get; set; }
        public string descr { get; set; }
        public string examples { get; set; }
    }


}
