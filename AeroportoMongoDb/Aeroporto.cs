using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeroportoMongoDb
{
    public class Aeroporto
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("loc")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Loc { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("code")]
        public string Code { get; set; }
    }
}
