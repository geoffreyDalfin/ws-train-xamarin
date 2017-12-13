using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Client.Models;
using Client.Views;
using Client.Views.Modals;
using Prism.Commands;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class TrajetViewModel : INotifyPropertyChanged
    {
        public object _locker = new object();

        private ArretViewModel arret;

        private ObservableCollection<arrets> _arret;
        private ObservableCollection<trajet> _trajets;

        public ICommand GetTrajet
        {
            get;
            private set;
        }

        public ICommand SelectedTrajet
        {
            get;
            private set;
        }

        public UtilisateurViewModel CurrentUser
        {
            get;
            set;
        }




        public trajet Item
        {
            get;
            set;
        }

        public int? IdTrajet
        {
            get
            {
                return this.Item.IdTrajet;
            }
            set
            {
                this.Item.IdTrajet = value;
                OnPropertyChanged("IdTrajet");
            }

        }

        public int VilleDepart
        {
            get
            {
                return this.Item.VilleDepart;
            }
            set
            {
                
                this.Item.VilleDepart = value;
                OnPropertyChanged("VilleDepart");
            }

        }

        public int VilleArrivee
        {

            get
            {
                return this.Item.VilleArrivee;
            }
            set
            {
                this.Item.VilleArrivee = value;
                OnPropertyChanged("VilleArrivee");
            }

        }

        public DateTime HeureDepart
        {

            get
            {
                return this.Item.HeureDepart;
            }
            set
            {
                this.Item.HeureDepart = value;
                OnPropertyChanged("HeureDepart");
            }

        }

        public DateTime HeureArrivee
        {

            get
            {
                return this.Item.HeureArrivee;
            }
            set
            {
                this.Item.HeureArrivee = value;
                OnPropertyChanged("HeureArrivee");
            }

        }

        public String VilledeDepart { get; set; }
        public String VilleDarrivee { get; set; }



        public string VilleDeparts
        {
            get
            {
                if (Item.arrets.First().ville.NomVille == null)
                    return "";
                else
                    return Item.arrets.First().ville.NomVille;
            }
        }

        public string VilleArrivees
        {
            get
            {
                if (Item.arrets.Last().ville.NomVille == null)
                    return "";
                else 
                    return Item.arrets.Last().ville.NomVille;
            }
        }



        public ICollection<arrets> Arrets
        {
            get
            {
                return this.Item.arrets;
            }

        }


        public List<TrajetViewModel> ListTrajet
        {
            get;
            set;
        }



        public TrajetViewModel()
        {
            GetTrajet = new DelegateCommand(
              async () =>
            {
                if (!string.IsNullOrEmpty(VilledeDepart) && !string.IsNullOrEmpty(VilleDarrivee))
                {
                    var responsetrajet = await Helpers.TrajetService.GetTrajet(VilledeDepart, VilleDarrivee);
                    if (responsetrajet.Count != 0)
                    {
                        ListTrajet = new List<TrajetViewModel>();
                        foreach (var item in responsetrajet)
                        {
                            trajet trjt = new trajet()
                            {
                                IdTrajet = item.IdTrajet,
                                VilleDepart = item.VilleDepart,
                                VilleArrivee = item.VilleArrivee,
                                HeureDepart = item.HeureDepart,
                                HeureArrivee = item.HeureArrivee,
                                arrets = item.arrets
                            };
                            ListTrajet.Add(new TrajetViewModel() { Item = trjt });
                        }
                        var listtrajet = new ListTrajetPage(this);
                        NavigationPage.SetHasBackButton(listtrajet, true);
                        NavigationPage.SetHasNavigationBar(listtrajet, true);
                        await Application.Current.MainPage.Navigation.PushAsync(listtrajet);
                    }
                }else{
                    await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez insérer une ville de départ et d'arrivée", "OK");
                    return;
                }
            });

            SelectedTrajet = new DelegateCommand<TrajetViewModel>(
               async (trajet) =>
            {
                ValidateTrajet popUp = new ValidateTrajet(trajet);
                await Application.Current.MainPage.Navigation.PushPopupAsync(popUp);
                popUp.Disappearing += async (sender, e) =>
                    {
                        if (popUp.ChoiceUser == true)
                        {
                            Debug.WriteLine(popUp.NbPassager);
                            reserve reservation = new reserve
                            {
                                IdUser = CurrentUser.Id,
                                IdGareDepart = VilleDepart,
                                IdGareArrivee = VilleArrivee,
                                NbBillets = popUp.NbPassager,
                                DateReservation = DateTime.Now,
                                DateDepart = DateTime.Now
                            };
                            CurrentUser.Item.reserve.Add(reservation);
                            await Application.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            return;
                        }
                    };
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
