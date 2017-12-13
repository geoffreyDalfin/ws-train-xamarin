using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class ReservePage : ContentPage
    {
        public ReservePage(UtilisateurViewModel CurrentUser)
        {
            InitializeComponent();
            this.BindingContext = CurrentUser;
            if(CurrentUser.Reserve.Count == 0)
            {
                img.IsVisible = true;
                lstReserve.IsVisible = false;
            }else{
                img.IsVisible = false;
                lstReserve.IsVisible = true;
            }
        }
    }
}
