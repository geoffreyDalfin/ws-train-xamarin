using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public object _locker = new object();

        private ObservableCollection<reserve> _reserve;


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

        public ICommand GoToInscription
        {
            get;
            private set;
        }

        public ICommand GoToReservation
        {
            get;
            private set;
        }

        public ICommand GoToProfile
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

        public String NomPrenom
        {
            get
            {
                return this.Prenom + " " + this.Nom;
            }
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


        public ICollection<reserve> Reserve
        {
            get
            {
                return this.Item.reserve;

            }

        }


        public UtilisateurViewModel()
        {
            Item = new utilisateur();
            GetUserExist = new DelegateCommand(
                async () =>
                {
                    if (!string.IsNullOrWhiteSpace(Mail) && !string.IsNullOrWhiteSpace(MotPasse))
                    {
                        utilisateur response = await Helpers.UtilisateurService.GetUser(Mail, MotPasse);
                        if (response.IdUser != 0)
                        {
                            var trajet = new TrajetPage(new TrajetViewModel() { Item = new trajet() }, new UtilisateurViewModel() { Item = response });
                            NavigationPage.SetHasBackButton(trajet, false);
                            NavigationPage.SetHasNavigationBar(trajet, true);
                            Application.Current.Properties["email"] = this.Mail;
                            Application.Current.Properties["password"] = this.MotPasse;
                            await Application.Current.MainPage.Navigation.PushAsync(trajet);
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Erreur", "Email ou mot de passe incorrect", "OK");
                            return;
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez rentrer votre email ou mot de passe", "OK");

                        return;
                    }
                });

            CreateUser = new DelegateCommand(
                async () =>
                {
                    var response = await Helpers.UtilisateurService.PostUserAsync(Item);
                    if (response == true)
                    {
                        await Application.Current.MainPage.DisplayAlert("Succès", "Utilisateur créer", "OK");
                        return;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erreur", "Problème lors de la création de l'utilisateur", "OK");
                        return;
                    }
                });
            GoToInscription = new DelegateCommand(
                async () =>
                {
                    var inscription = new RegisterPage(new UtilisateurViewModel() { Item = Item });
                    NavigationPage.SetHasBackButton(inscription, true);
                    NavigationPage.SetHasNavigationBar(inscription, true);
                    await Application.Current.MainPage.Navigation.PushAsync(inscription);
                });
            GoToReservation = new DelegateCommand(
                async () =>
                {
                    var reservation = new ReservePage(this);
                    NavigationPage.SetHasBackButton(reservation, true);
                    NavigationPage.SetHasNavigationBar(reservation, true);
                    await Application.Current.MainPage.Navigation.PushAsync(reservation);
                });
            GoToProfile = new DelegateCommand(
                async () =>
                {
                    var profile = new UserPage(this);
                    NavigationPage.SetHasBackButton(profile, true);
                    NavigationPage.SetHasNavigationBar(profile, true);
                    await Application.Current.MainPage.Navigation.PushAsync(profile);
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
