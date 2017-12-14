using System.Threading.Tasks;
using Client.Models;
using Client.ViewModels;
using Client.Views;
using Xamarin.Forms;

namespace Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password"))
            //{
            //    var email = Application.Current.Properties["email"] as string;
            //    var password = Application.Current.Properties["password"] as string;
            //    GetConnection(email, password);
            //}
            //else
            //{
                MainPage = new NavigationPage(new Views.ConnexionPage());
            //}
        }


        //public async void GetConnection(string email, string password)
        //{
        //    var response = Helpers.UtilisateurService.GetUserAuto(email, password);
        //    if (response != null)
        //    {
        //        var trajet = new TrajetPage(new TrajetViewModel() { Item = new trajet() }, new UtilisateurViewModel() { Item = response });
        //        NavigationPage.SetHasBackButton(trajet, false);
        //        NavigationPage.SetHasNavigationBar(trajet, true);
        //        await Application.Current.MainPage.Navigation.PushAsync(trajet);
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
