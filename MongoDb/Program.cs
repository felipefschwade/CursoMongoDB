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

            var filtro = Builders<Livro>.Filter.Eq(l => l.Autor, "M. De Assis");
            Console.WriteLine("Excluido os Livros de M. Assis");
            var livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
                await livrosCollection.ReplaceOneAsync(filtro, livro);
            }

            await livrosCollection.DeleteManyAsync(filtro);

            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
                await livrosCollection.ReplaceOneAsync(filtro, livro);
            }

            Console.ReadKey();
        }
    }
}
