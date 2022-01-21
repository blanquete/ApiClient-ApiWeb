using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApiRest.DAL.Model;
using ToDoListApiRest.DAL.Persistence;


namespace ToDoListApiRest.DAL.Service
{
    public class UserService
    {
        public List<Tasca> GetAll()
        {
            IMongoCollection<Tasca> tasques = DbContext.GetTasques();

            List<Tasca> result = tasques.AsQueryable<Tasca>().ToList();
            return result;
        }

        public List<Tasca> Select(int estat)
        {
            List<Tasca> tasques_ = GetAll();
            List<Tasca> tasques = new List<Tasca>();

            foreach (Tasca t in tasques_)
            {
                if (t.Estat == (Estat)estat)
                {
                    tasques.Add(t);
                }
            }
            return tasques;
        }

        public Tasca Select(ObjectId id)//*/(int id)
        {
            List<Tasca> tasques = GetAll();

            foreach (Tasca t in tasques)
            {
                if (t.Id == id)//*/(t._Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        public void Add(Tasca tasca)
        {
            IMongoCollection<Tasca> tasques = DbContext.GetTasques();

            tasques.InsertOne(tasca);
        }

        public void Update(Tasca tasca)
        {
            IMongoCollection<Tasca> tasques = DbContext.GetTasques();

            var filtre = Builders<Tasca>.Filter.Eq(s => s.Id, tasca.Id);
            var result = tasques.ReplaceOne(filtre, tasca);
        }

        public void Delete(int Id)//(ObjectId Id)
        {
            IMongoCollection<Tasca> tasques = DbContext.GetTasques();

            var result = tasques.DeleteOne(s => s._Id == Id);//(s => s.Id == Id);
        }







        /// <summary>
        /// Obté tots els usuaris
        /// </summary>
        /// <returns></returns>
        public List<Prioritat> SelectP()
        {
            IMongoCollection<Prioritat> prioritats = DbContext.GetPrioritats();

            List<Prioritat> result = prioritats.AsQueryable<Prioritat>().ToList();
            return result;
        }

        /// <summary>
        /// Obté tots els usuaris
        /// </summary>
        /// <returns></returns>
        public List<Responsable> SelectR()
        {
            IMongoCollection<Responsable> respnsables = DbContext.GetResponsables();

            List<Responsable> result = respnsables.AsQueryable<Responsable>().ToList();
            return result;
        }

        /// <summary>
        /// Afegeix un nou usuari a la base de dades
        /// </summary>
        /// <param name="tasca">Entitat usuari</param>
        public void afegirResponsable(Responsable responsable)
        {
            IMongoCollection<Responsable> responsables = DbContext.GetResponsables();

            responsables.InsertOne(responsable);
        }

        /// <summary>
        /// Actualitza un usuari
        /// </summary>
        /// <param name="tasca">Entitat usuari que es vol modificar</param>



        public void updateEstat(Tasca tasca)
        {
            IMongoCollection<Tasca> tasques = DbContext.GetTasques();

            var filtre = Builders<Tasca>.Filter.Eq(s => s.Id, tasca.Id);
            var result = tasques.ReplaceOne(filtre, tasca);
        }

        /// <summary>
        /// Elimina un usuari
        /// </summary>
        /// <param name="Id">Codi d'usuari que es vol eliminar</param>
        public int maxId()
        {
            List<Tasca> tasques = GetAll();

            try
            {
                var max_id = tasques[tasques.Count - 1]._Id;
                return max_id;
            }
            catch
            {
                return 1;
            }
        }
    }
}
