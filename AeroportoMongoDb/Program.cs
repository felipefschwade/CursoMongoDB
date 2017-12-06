using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Threading.Tasks;

namespace AeroportoMongoDb
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var coordenadas = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(coordenadas);

            var filtro = Builders<Aeroporto>.Filter.NearSphere(e => e.Loc, localizacao, 100000);
            var lista = await  MongoDbConnector.AirportsCollection.Find(filtro).ToListAsync();
            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.ToJson<Aeroporto>());
            }
            Console.ReadKey();
        }
    }
}
