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

            var filtro = new BsonDocument() { { "Autor", "Machado de Assis" } };
            Console.WriteLine("Livros do Machado De Assis");
            var livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            var filtroComBuilder = Builders<Livro>.Filter;
            var condicoes = filtroComBuilder.Eq(p => p.Autor, "Machado de Assis");
            Console.WriteLine("Livros do Machado De Assis com Filtro");
            livros = await livrosCollection.Find(condicoes).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            filtroComBuilder = Builders<Livro>.Filter;
            condicoes = filtroComBuilder.Gte(p => p.Paginas, 200);
            Console.WriteLine("Livros com mais de 200 páginas");
            livros = await livrosCollection.Find(condicoes).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            filtroComBuilder = Builders<Livro>.Filter;
            condicoes = filtroComBuilder.Gte(p => p.Paginas, 200) & filtroComBuilder.Gte(l => l.Ano, 1999);
            Console.WriteLine("Livros com mais de 200 páginas e a partir de 1999");
            livros = await livrosCollection.Find(condicoes).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            filtroComBuilder = Builders<Livro>.Filter;
            condicoes = filtroComBuilder.AnyEq(p => p.Assuntos, "Ficção Científica");
            Console.WriteLine("Livros de Ficção Científica");
            livros = await livrosCollection.Find(condicoes).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            filtroComBuilder = Builders<Livro>.Filter;
            condicoes = filtroComBuilder.Gt(p => p.Paginas, 100);
            Console.WriteLine("Livros Com mais de 100 páginas em ordem alfabética");
            livros = await livrosCollection.Find(condicoes).SortBy(l => l.Titulo).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.ReadKey();
        }
    }
}
