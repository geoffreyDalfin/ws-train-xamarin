using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class TrajetPage : ContentPage
    {
        public TrajetPage(UtilisateurViewModel user)
        {
            InitializeComponent();
            this.BindingContext = user;
            test.Text = "Bravo " + user.Nom + ", tu es passé :) ";
        }
    }
}
