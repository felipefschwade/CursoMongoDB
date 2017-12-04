using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MongoDb
{
    public class LivroDAO
    {
        private readonly IMongoCollection<Livro> _collection;

        public LivroDAO()
        {
            _collection = MongoDBConnector.GetLivrosCollection;
        }

        public static Livro CriaLivro(string titulo, string autor, int ano, int paginas, string assuntos)
        {
            var Livro = new Livro()
            {
                Titulo = titulo,
                Autor = autor,
                Ano = ano,
                Paginas = paginas,
                Assuntos = new List<string>()
            };

            foreach (var assunto in assuntos.Split(","))
            {
                Livro.Assuntos.Add(assunto.Trim());
            }

            return Livro;
        }
    }
}
