using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Client.Models;
using Client.Views;
using Prism.Commands;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class UtilisateurViewModel : INotifyPropertyChanged
    {

        public ICommand GetUserExist
        {
            get;
            private set;
        }

        public ICommand CreateUser
        {
            get;
            private set;
        }


        public utilisateur Item
        {
            get;
            set;

        }

        public int Id
        {
            get { return this.Item.IdUser; }
        }

        public String Nom
        {
            get
            {
                return this.Item.Nom;
            }
            set
            {
                this.Item.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public String Prenom
        {
            get
            {
                return this.Item.Prenom;
            }
            set
            {
                this.Item.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        public String Mail
        {
            get
            {
                return this.Item.Mail;
            }
            set
            {
                this.Item.Mail = value;
                OnPropertyChanged("Mail");
            }
        }

        public String MotPasse
        {
            get
            {
                return this.Item.MotPasse;
            }
            set
            {
                this.Item.MotPasse = value;
                OnPropertyChanged("MotPasse");
            }
        }



        public UtilisateurViewModel()
        {
            Item = new utilisateur();
            GetUserExist = new DelegateCommand(
                async () =>
                {
                    var response = await Helpers.UtilisateurService.GetUser(Mail, MotPasse);
                    if (response != null)
                    {
                    var trajet = new TrajetPage(new UtilisateurViewModel(){Item = response});
                        NavigationPage.SetHasBackButton(trajet, false);
                        NavigationPage.SetHasNavigationBar(trajet, false);
                        await Application.Current.MainPage.Navigation.PushAsync(trajet);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erreur", "Email ou mot de passe incorrect", "OK");
                        return;
                    }

                });

            CreateUser = new DelegateCommand(
                () =>
                {

                });

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
