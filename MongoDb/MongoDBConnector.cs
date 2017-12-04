using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb
{
    public class MongoDBConnector
    {
        const string BANCO_DE_DADOS = "Biblioteca";
        public const string ConnectionString = "mongodb://localhost:27017";

        public static IMongoCollection<Livro> GetLivrosCollection { get { return BancoDeDados.GetCollection<Livro>("Livros"); } }

        public static IMongoClient Client = new MongoClient(ConnectionString);

        public static IMongoDatabase BancoDeDados = Client.GetDatabase(BANCO_DE_DADOS);
    }
}
