using System;
using System.Collections.Generic;
using Client.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Client.Views.Modals
{
    public partial class ValidateTrajet : PopupPage
    {
        private int nbpassager;
        private bool choiceuser;

        public int NbPassager
        {
            get{
                return this.nbpassager;
            }
            set{
                this.nbpassager = value;
            }
        }

        public bool ChoiceUser
        {
            get{
                return this.choiceuser;
            }
            set{
                this.choiceuser = value;
            }
        }



        public ValidateTrajet()
        {

        }

        public ValidateTrajet(TrajetViewModel trajet)
        {
            InitializeComponent();
            this.BindingContext = trajet;
            _countnbpassager.Items.Add("1");
            _countnbpassager.Items.Add("2");
            _countnbpassager.Items.Add("3");
            _countnbpassager.Items.Add("4");
            _countnbpassager.Items.Add("5");
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var nbcount = _countnbpassager.Items[_countnbpassager.SelectedIndex];
            nbpassager = int.Parse(nbcount);
        }

        async void Validate_Clicked(object sender, System.EventArgs e)
        {
            choiceuser = true;
            await PopupNavigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            choiceuser = false;
            await PopupNavigation.PopAsync();
        }
    }
}
