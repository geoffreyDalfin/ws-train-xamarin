using System;
using System.Collections.Generic;
using Client.Models;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class ReservePage : ContentPage
    {
        public UtilisateurViewModel User
        {
            get;
            set;
        }

        public ReservePage(UtilisateurViewModel CurrentUser)
        {
            InitializeComponent();
            this.BindingContext =  User = CurrentUser;
            if(CurrentUser.Reserve.Count == 0)
            {
                img.IsVisible = true;
                lstReserve.IsVisible = false;
            }else{
                img.IsVisible = false;
                lstReserve.IsVisible = true;
            }
        }

       async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var reseration = (reserve)mi.CommandParameter;
            if (User.Reserve.Contains(reseration)) 
            {
                User.Reserve.Remove(reseration);
               await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
