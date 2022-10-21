using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace LanguageDict.Models
{
    internal class DataBs
    {
        public static MongoClient _client { get; set; }
        public bool clientStatus { get; private set; }
        public IMongoDatabase _dataBase { get; private set; }

        public DataBs()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _dataBase = _client.GetDatabase("dotnetWebServices");
            Test();
        }

        private IMongoCollection<BsonDocument> getCollection(string collec)
        {
            var collection = _dataBase.GetCollection<BsonDocument>(collec);
            return collection;
        }

        public bool addNewDict(Dict dictionary)
        {
            var collection = getCollection("Dictionaries");

            string strTrie = JsonSerializer.Serialize<Trie>(dictionary.Trie);
            string strAllWords = JsonSerializer.Serialize<ObservableCollection<Words>>(dictionary.allWorlds);

            var document = new BsonDocument
            {
                {"Native", dictionary.Native},
                {"Target", dictionary.Target},
                {"Description", dictionary.Description},
                {"Trie", strTrie},
                {"AllWords", strAllWords}
            };

            return false;
        }

        public void removeDict(Dict dictionary)
        {
            var collection = getCollection("Dictionaries");
        }



        public void addNewWord(string word)
        {

        }

        public void removeWord(string word)
        {

        }

        public void searchWord(string word)
        {

        }

        private void Test()
        {
            var database = _client.GetDatabase("donetWebServices");
            var collection = database.GetCollection<BsonDocument>("Products");

            var doc = new BsonDocument
            {
                { "Word", "Test" },
                { "Translation", "Test translation" },
                { "Meaning", "Test meaning" },
            };

            try
            {
                collection.InsertOne(doc);
                clientStatus = true;
            }
            catch (Exception ex)
            {
                clientStatus = false;
            }
            finally
            {

            }
        }
    }
}
