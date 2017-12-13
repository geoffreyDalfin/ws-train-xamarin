using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class ConnexionPage : ContentPage
    {
        public ConnexionPage(): this(new UtilisateurViewModel(){Nom = "", Prenom="", Mail="", MotPasse=""})
        {}
        public ConnexionPage(UtilisateurViewModel item)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = item;
            if(_email.Text!=null && _password.Text !=null)
            {
                _btnconnexion.IsEnabled = true;
            }
        }
    }
}
