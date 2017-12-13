using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Client.Models;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class ListTrajetPage : ContentPage
    {
        public ListTrajetPage(TrajetViewModel Trajet)
        {
            InitializeComponent();

            this.BindingContext = Trajet;
            this.Title = "Un trajet pour "+Trajet.VilledeDepart+"-"+Trajet.VilleDarrivee;
        }
    }
}
