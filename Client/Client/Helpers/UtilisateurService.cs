using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Newtonsoft.Json;

namespace Client.Helpers
{
    public class UtilisateurService
    {
        public UtilisateurService()
        {
            
        }

        public static async Task<bool> GetUser(string mail, string mdp)
        {
            var user = new utilisateur();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //var result = await httpClient.GetAsync("http://90/113/132/13:7850/api/utilisateur/GetByMail/" + mail + "/");

                    var result = await httpClient.GetAsync("http://192.168.1.18/api/utilisateur/GetByMail/"+mail+"/");

                    var responseText = await result.Content.ReadAsStringAsync();
                    //Serialize the json object to our c# classes
                    var Object = JsonConvert.DeserializeObject<utilisateur>(responseText);

                    if (Object != null)
                    {
                        user = new utilisateur
                        {
                            IdUser = Object.IdUser,
                            Nom = Object.Nom,
                            Prenom = Object.Prenom,
                            Mail = Object.Mail,
                            MotPasse = Object.MotPasse
                        };
                        if( mdp != user.MotPasse)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //In case we have a problem...
                Debug.WriteLine("Un probleme pour récupérer l'utilisateur " + ex.Message);
            }
            return true;
        }

        public static void PostUser(utilisateur newuser)
        {
            var contentpost = JsonConvert.SerializeObject(newuser);
            var content = new StringContent(contentpost, Encoding.UTF8, "application/json");
            try{
                using (var httpClient = new HttpClient())
                {
                    //var send = httpClient.PostAsync("http://90/113/132/13:7850/api/utilisateurs/", content);
                    var send = httpClient.PostAsync("http://192.168.1.18/api/utilisateurs/", content);
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Un problème pour crééer l'utilisateur " + ex.Message);
            }
        }

    }
}
