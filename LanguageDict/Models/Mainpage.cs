using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LanguageDict.Models
{
    internal class Mainpage
    {
        public ObservableCollection<Dict> AllDictionaries { get; set; } = new ObservableCollection<Dict>();
        public string dataPath = "C:\\Users\\luanG\\Documents\\GitHub\\DictionaryApp\\LanguageDict\\Data\\dados.json";
        public string selectedPath = "C:\\Users\\luanG\\Documents\\GitHub\\DictionaryApp\\LanguageDict\\Data\\selectedDict.json";

        public Mainpage()
        {
            AllDictionaries.Clear();
            Load();
        }

        public void Load()
        {
            using (StreamReader r = new StreamReader(dataPath))
            {
                string json = r.ReadToEnd();
                List<Dict> items = JsonConvert.DeserializeObject<List<Dict>>(json);

                foreach(var item in items)
                {
                    Dict nDict = new Dict();
                    nDict.Native = item.Native;
                    nDict.Target = item.Target;
                    nDict.Image = item.Image;
                    nDict.Trie = item.Trie;
                    nDict.words = item.words;
                    AllDictionaries.Add(nDict);
                }
            }
        }

        public List<Dict> ReadData(string path)
        {
            using (StreamReader strReader = new StreamReader(path))
            {
                string json = strReader.ReadToEnd();
                strReader.Close();
                List<Dict> items = JsonConvert.DeserializeObject<List<Dict>>(json);
                return items;
            }
        }

        public void WriteData(string files, string path)
        {
            using (StreamWriter strWriter = new StreamWriter(path))
            {
                strWriter.Write(files);
                strWriter.Close();
            }
        }
    }
}
