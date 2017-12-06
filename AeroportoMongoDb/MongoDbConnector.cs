using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeroportoMongoDb
{
    public class MongoDbConnector
    {
        const string BANCO_DE_DADOS = "geo";
        public const string ConnectionString = "mongodb://localhost:27017";

        public static IMongoCollection<Aeroporto> AirportsCollection { get { return BancoDeDados.GetCollection<Aeroporto>("airports"); } }

        public static IMongoClient Client = new MongoClient(ConnectionString);

        public static IMongoDatabase BancoDeDados = Client.GetDatabase(BANCO_DE_DADOS);
    }
}
