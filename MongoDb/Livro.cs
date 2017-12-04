using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public IList<string> Assuntos { get; set; }

    }
}
