using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb
{
    public class MongoDBConnector
    {
        public static IMongoCollection<Livro> GetCollection(string collection)
        {
            return BancoDeDados.GetCollection<Livro>(collection);
        }

        public const string ConnectionString = "mongodb://localhost:27017";

        public static IMongoClient Client = new MongoClient(ConnectionString);

        public static IMongoDatabase BancoDeDados = BancoDeDados = Client.GetDatabase("Biblioteca");
    }
}
