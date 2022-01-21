using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ToDoListApiRest.DAL.Model
{
    public class Prioritat
    {


        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int _Id { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        /*
        //Declaració de variables
        private int id;
        private string nom;

        //Constructor
        public Prioritat()
        {
            id = 0;
            nom = "";
        }
        public Prioritat(int id_, string nom_)
        {
            id = id_;
            nom = nom_;
        }

        //Accesors
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        */
    }
}
