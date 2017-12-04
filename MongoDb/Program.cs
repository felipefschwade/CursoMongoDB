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

            var filtro = Builders<Livro>.Filter.Eq(l => l.Titulo, "Game of Thrones");
            Console.WriteLine("Alterando o Game of Thrones");
            var livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
                livro.Ano = livro.Ano + 1;
                livro.Paginas = livro.Paginas + 1;
                await livrosCollection.ReplaceOneAsync(filtro, livro);
            }

            filtro = Builders<Livro>.Filter.Eq(l => l.Titulo, "Game of Thrones");
            Console.WriteLine("Game of Thrones Alterado");
            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            Console.WriteLine("Under The Dome Antes");
            filtro = Builders<Livro>.Filter.Eq(l => l.Titulo, "Under The Dome");
            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }
            var filtroUpdate = Builders<Livro>.Update.Set(l => l.Ano, 2014);
            Console.WriteLine("Alterando o Under the Dome");
            await livrosCollection.UpdateOneAsync(filtro, filtroUpdate);
            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine();

            Console.WriteLine("Alterando os livros do machado de Assis");
            filtro = Builders<Livro>.Filter.Eq(l => l.Autor, "Machado de Assis");
            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }
            filtroUpdate = Builders<Livro>.Update.Set(l => l.Autor, "M. De Assis");
            Console.WriteLine("Alterando os livros do machado de Assis");
            await livrosCollection.UpdateManyAsync(filtro, filtroUpdate);
            filtro = Builders<Livro>.Filter.Eq(l => l.Autor, "M. De Assis");
            livros = await livrosCollection.Find(filtro).ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
