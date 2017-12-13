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
        public static utilisateur GetUserAuto(string mail, string mdp)
        {
            var user = new utilisateur();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //var result = await httpClient.GetAsync("http://90.113.132.13:7850/api/utilisateur/GetByMail/" + mail + "/");

                    var result = httpClient.GetAsync("http://192.168.1.18/api/utilisateur/GetByMail/" + mail + "/");

                    var responseText = result.Result.Content.ReadAsStringAsync();
                    //Serialize the json object to our c# classes
                    var Object = JsonConvert.DeserializeObject<utilisateur>(responseText.Result);

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
                        if (user.IdUser == 0)
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //In case we have a problem...
                Debug.WriteLine("Un probleme pour récupérer l'utilisateur " + ex.Message);
            }
            return user;
        }

        public static async Task<utilisateur> GetUser(string mail, string mdp)
        {
            var user = new utilisateur();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //var result = await httpClient.GetAsync("http://90.113.132.13:7850/api/utilisateur/GetByMail/" + mail + "/");

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
                        if( user.IdUser == 0)
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //In case we have a problem...
                Debug.WriteLine("Un probleme pour récupérer l'utilisateur " + ex.Message);
            }
            return user;
        }

        public static async Task<bool> PostUserAsync(utilisateur newuser)
        {
            bool res;
            var contentpost = JsonConvert.SerializeObject(newuser);
            var content = new StringContent(contentpost, Encoding.UTF8, "application/json");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //var send = await httpClient.PostAsync("http://90/113/132/13:7850/api/utilisateurs", content);
                    var send = await httpClient.PostAsync("http://192.168.1.18/api/utilisateurs", content);
                    if (send.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Un problème pour crééer l'utilisateur " + ex.Message);
                return false;
            }
            return res;
        }

    }
}
