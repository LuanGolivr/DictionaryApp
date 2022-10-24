using MongoDB.Bson.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace LanguageDict.Models
{
    public class Main
    {
        public ObservableCollection<Dict> AllDictionaries { get; set; } = new ObservableCollection<Dict>();
        public DataBs serverConnection { get; set; }

        public Main()
        {
            makeConnectionServer();
            AllDictionaries.Clear();
            LoadData();
        }

        private void makeConnectionServer()
        {
            serverConnection = new DataBs();
        }

        public void LoadData()
        {
            AllDictionaries.Clear();
            var data = serverConnection.GetDict();

            for (int i = 0; i < data.Count; i++)
            {
                data[i].RemoveAt(0);
                var nObj= BsonSerializer.Deserialize<Dict>(data[i]);

                AllDictionaries.Insert(i, nObj);
            }
        }
    }
}
