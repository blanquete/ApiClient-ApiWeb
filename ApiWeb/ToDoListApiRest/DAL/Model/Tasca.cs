//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApiRest.DAL.Model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace ToDoListApiRest.DAL.Model
{
    public enum Estat
    {
        Default,
        ToDo,
        Doing,
        Done
    }
    public class Tasca
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int _Id { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        [BsonElement("descripcio")]
        public string Descripcio { get; set; }

        [BsonElement("dInici")]
        public DateTime DInici { get; set; }
        [BsonElement("dFinal")]
        public DateTime DFinal { get; set; }

        [BsonElement("prioritat_id")]
        public int Prioritat_id { get; set; }

        [BsonElement("responsable_name")]
        public string Responsable_name { get; set; }

        [BsonElement("estat")]
        public Estat Estat { get; set; }

        [BsonElement("estat_name")]
        public string Estat_name { get; set; }

        [BsonElement("prioritat_name")]
        public string Prioritat_name { get; set; }

        [BsonElement("responsable_id")]
        public int Responsable_id { get; set; }
        //public string Estat_name { get; set; }

    }/**/

    /*public class Tasca
    {
        
        private int id;
        private string nom;
        private string descripcio;
        private DateTime dInici;
        private DateTime dFinal;
        private int prioritat_id;
        private string prioritat_name;
        private int responsable_id;
        private string responsable_name;
        private string estat_name;
        private Estat estat;


        //Constructors 
        public Tasca()
        {
            id = 0;
            nom = "";
            descripcio = "";
            dInici = new DateTime();
            dFinal = new DateTime();
            prioritat_id = 0;
            prioritat_name = "";
            responsable_id = 0;
            responsable_name = "";
            estat_name = "";
            estat = (Estat)0;
        }
        public Tasca(int id_, string nom_, string descripcio_, DateTime dInici_, DateTime dFinal_, int prioritat_id_, string prioritat_name_, int responsable_id_, string responsable_name_, string estat_name_, Estat estat_)
        {
            id = id_;
            nom = nom_;
            descripcio = descripcio_;
            dInici = dInici_;
            dFinal = dFinal_;
            prioritat_id = prioritat_id_;
            prioritat_name = prioritat_name_;
            responsable_id = responsable_id_;
            responsable_name = responsable_name_;
            estat_name = estat_name_;
            estat = estat_;
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
        public string Descripcio
        {
            get { return descripcio; }
            set { descripcio = value; }
        }
        public DateTime DInici
        {
            get { return dInici; }
            set { dInici = value; }
        }
        public DateTime DFinal
        {
            get { return dFinal; }
            set { dFinal = value; }
        }
        public int Prioritat_id
        {
            get { return prioritat_id; }
            set { prioritat_id = value; }
        }
        public string Prioritat_name
        {
            get { return prioritat_name; }
            set { prioritat_name = value; }
        }
        public int Responsable_id
        {
            get { return responsable_id; }
            set { responsable_id = value; }
        }
        public string Responsable_name
        {
            get { return responsable_name; }
            set { responsable_name = value; }
        }
        public string Estat_name
        {
            get { return estat_name; }
            set { estat_name = value; }
        }
        public Estat Estat
        {
            get { return estat; }
            set { estat = value; }
        }
    }*/
}
