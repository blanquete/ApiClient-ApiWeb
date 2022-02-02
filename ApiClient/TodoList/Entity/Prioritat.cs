using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entity
{
    public class Prioritat
    {

        [BsonId]
        public string Id { get; set; }

        [BsonElement("id")]
        public int _Id { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }
    }
}
