using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class TrajetPage : ContentPage
    {

        public TrajetViewModel MonTrajet
        {
            get;
            set;
        }

        public TrajetPage(TrajetViewModel trajet, UtilisateurViewModel user)
        {
            InitializeComponent();
            trajet.CurrentUser = user;
            this.BindingContext = MonTrajet = trajet;

            this.Title = "Un trajet " + trajet.CurrentUser.Nom + " ?";

        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            _villedepart.Text = "";
            _villearrivee.Text = "";

        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            //MonTrajet.VilledeDepart = "";
            //MonTrajet.VilleDarrivee = "";
        }
    }
}
