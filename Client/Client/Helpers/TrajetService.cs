using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models;
using Newtonsoft.Json;

namespace Client.Helpers
{
    public class TrajetService
    {
        public static List<trajet> lsttrajet;
        public TrajetService()
        {
            lsttrajet = new List<trajet>();
        }

        public static async Task<List<trajet>> GetTrajet(string villedepart, string villearrivee)
        {
            var trajet = new trajet();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //var result = await httpClient.GetAsync("http://90.113.132.13:7850/api/trajet/GetByVilles/" + villedepart + "/"+villearrivee);

                    var result = await httpClient.GetAsync("http://192.168.1.18/api/trajet/GetByVilles/" + villedepart + "/"+villearrivee);

                    var responseText = await result.Content.ReadAsStringAsync();
                    //Serialize the json object to our c# classes
                    lsttrajet = JsonConvert.DeserializeObject<List<trajet>>(responseText);


                }
            }
            catch (Exception ex)
            {
                //In case we have a problem...
                Debug.WriteLine("Un probleme pour récupérer les trajets " + ex.Message);
            }
            return lsttrajet;
        }
    }
}
