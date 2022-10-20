﻿using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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
                .
            var document = new BsonDocument
            {
                {"Native", dictionary.Native},
                {"Target", dictionary.Target},
                {"Description", dictionary.Description},
            };

            return false;
        }

        public void removeDict(Dict dictionary)
        {
            var collection = getCollection("Dictionaries");
        }



        public BsonDocument addNewWord(string word)
        {

        }

        public BsonDocument removeWord(string word)
        {

        }

        public BsonDocument searchWord(string word)
        {

        }

        private void Test()
        {
            var database = _client.GetDatabase("donetWebServices");
            var collection = database.GetCollection<BsonDocument>("Products");
            int[] testes {1,2,3}

            var doc = new BsonDocument
            {
                { "Word", "Test" },
                { "Translation", "Test translation" },
                { "Meaning", "Test meaning" },
                {"Examples", testes},
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
