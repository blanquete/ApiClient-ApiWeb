using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entity;

namespace TodoList.TascaApi
{
    public class TascaApiClient
    {
        string BaseUri;

        public TascaApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
        }

        public async Task<List<Prioritat>> GetPrioritats()
        {
            List<Prioritat> prioritats = new List<Prioritat>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("prioritats");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    prioritats = await response.Content.ReadAsAsync<List<Prioritat>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return prioritats;
        }

        public async Task<List<Responsable>> GetResponsable()
        {
            List<Responsable> responsables = new List<Responsable>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("responsables");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    responsables = await response.Content.ReadAsAsync<List<Responsable>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return responsables;
        }

        public async Task<int> maxId()
        {
            List<Tasca> tasques = await GetTasquesAsync();

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


        //Añadir un responsable.

        public async Task AfegirResponsable(Responsable responsable)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                HttpResponseMessage response = await client.PostAsJsonAsync("responsables", responsable);
                response.EnsureSuccessStatusCode();
            }
           
        }

        /// <summary>
        /// Obté una tasca a partir del Id
        /// </summary>
        /// <param name="Tasca">Codi de Tasca</param>
        /// <returns>Tasca o null si no el troba</returns>
        //Funció per poder fer un select de totes les nostres tasques.
        public async Task<Tasca> GetTascaAsync(int estat)
        {
            Tasca tasca = new Tasca();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca/{Id}
                HttpResponseMessage response = await client.GetAsync($"tasques/{estat}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        tasca = null;
                    }
                    else
                    {
                        //Obtenim el resultat i el carreguem al Objecte Tasca
                        tasca = await response.Content.ReadAsAsync<Tasca>();
                        response.Dispose();
                    }
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? 
                }
            }
            return tasca;
        }

        /// <summary>
        /// Obté una llista de totes les tasques de la base de dades
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tasca>> GetTasquesAsync()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("tasques/1");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tasques;
        }
        public async Task<List<Tasca>> GetTasquesToDo()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("tasques/1");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tasques;
        }

        public async Task<List<Tasca>> GetTasquesDoing()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("tasques/2");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tasques;
        }
        public async Task<List<Tasca>> GetTasquesDone()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("tasques/3");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tasques;
        }

        /// <summary>
        /// Afegeix una nova tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem afegir</param>
        /// <returns></returns>
        public async Task AddAsync(Tasca tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("tasques", tasca);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar una tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(Tasca tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"tasques/{tasca._Id}", tasca);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar una tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem modificar</param>
        /// <returns></returns>
        public async Task DeleteAsync(Tasca tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"tasques/{tasca._Id}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}

