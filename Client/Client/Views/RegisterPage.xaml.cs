﻿using System;
using System.Collections.Generic;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(UtilisateurViewModel user)
        {
            InitializeComponent();
            this.BindingContext = user;
        }
    }
}
