using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApiRest.DAL.Model;
//using System.Data.SQLite;
using MongoDB.Driver;

using System.IO;

using Microsoft.Extensions.Configuration;

namespace ToDoListApiRest.DAL.Persistence
{
    public class DbContext
    {
        public static IMongoDatabase GetInstance()
        {
            string connectionString = "mongodb+srv://Iprats:Campalans1234@mongoproject.hxqyz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            MongoClient mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase("todolist");
        }

        public static IMongoCollection<Tasca> GetTasques()
        {
            return GetInstance().GetCollection<Tasca>("tasca");
        }

        public static IMongoCollection<Prioritat> GetPrioritats()
        {
            return GetInstance().GetCollection<Prioritat>("prioritat");
        }

        public static IMongoCollection<Responsable> GetResponsables()
        {
            return GetInstance().GetCollection<Responsable>("responsable");
        }

        /*public static SQLiteConnection GetInstance()
        {
            var configuration = GetConfiguration();

            //obtenim la cadena de connexió del fitxer de configuració
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("SQLite").Value;

            var db = new SQLiteConnection(
               string.Format(connectionString)
            );

            db.Open();

            return db;
        }

        /// <summary>
        /// Per agafar les dades del fitxer de configuració appsettings.json
        /// </summary>
        /// <returns></returns>
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }*/
    }
}
