using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var livro = new Livro()
            {
                Titulo = "Under The Dome",
                Autor = "Stephen King",
                Ano = 2012,
                Paginas = 679,
                Assuntos = new List<string>()
                {
                    "Ficcção Científica",
                    "Terror",
                    "Ação"
                }
            };
            var colection = MongoDBConnector.GetCollection("Livros");
            await colection.InsertOneAsync(livro);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
