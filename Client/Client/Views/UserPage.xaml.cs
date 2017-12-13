using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class UserPage : ContentPage
    {
        public UserPage(UtilisateurViewModel user)
        {
            InitializeComponent();
            this.BindingContext = user;
        }
    }
}
