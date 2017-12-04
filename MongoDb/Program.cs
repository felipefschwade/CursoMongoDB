using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var livrosCollection = MongoDBConnector.GetLivrosCollection;
            var livros = await livrosCollection.Find(new BsonDocument()).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }
            Console.ReadKey();
        }
    }
}
