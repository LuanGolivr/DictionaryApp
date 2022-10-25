using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;

namespace LanguageDict.Models
{
    public class DataBs
    {
        public static MongoClient _client { get; set; }
        public IMongoDatabase _dataBase { get; private set; }

        public DataBs()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _dataBase = _client.GetDatabase("dotnetWebServices");
        }

        private IMongoCollection<BsonDocument> getCollection(string collec)
        {
            var collection = _dataBase.GetCollection<BsonDocument>(collec);
            return collection;
        }

        public bool addNewDict(Dict dictionary)
        {
            var collection = getCollection("Dictionaries");
            bool result = searchDict(dictionary.Target);

            if(result == false)
            {
                var bsonDoc = dictionary.ToBsonDocument();
                

                collection.InsertOne(bsonDoc);
                return true;
            }

            return false;
        }

        public bool removeDict(Dict dictionary)
        {
            var collection = getCollection("Dictionaries");
            bool result = searchDict(dictionary.Target);

            if (result)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Target", dictionary.Target);
                collection.DeleteOne(filter);
                return true;
            }

            return false;
        }

        public bool searchDict(string lang)
        {
            var collection = getCollection("Dictionaries");
            var filter = Builders<BsonDocument>.Filter.Eq("Target", lang);
            var doc = collection.Find(filter).FirstOrDefault();

            if (doc != null)
            {
                return true;
            }

            return false;
        }


        public List<BsonDocument> GetDict()
        {
            var collection = getCollection("Dictionaries");

            var documents = collection.Find(new BsonDocument()).ToList();

            return documents;
        }

        public void SetSelected(Dict selectedDic)
        {
            var collection = getCollection("SelectedDic");
            bool result = searchDict(selectedDic.Target);
            var bsonDoc = selectedDic.ToBsonDocument();

            if (result)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Target", selectedDic.Target);
                collection.DeleteOne(filter);
            }

            collection.InsertOne(bsonDoc);
        }

        public Dict GetSelectedDict()
        {
            var collection = getCollection("SelectedDic");
            var document = collection.Find(new BsonDocument()).ToList();
            document[0].RemoveAt(0);

            var result = BsonSerializer.Deserialize<Dict>(document[0]);
            return result;
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
    }
}
