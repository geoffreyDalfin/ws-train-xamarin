using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Client.Models;

namespace Client.ViewModels
{
    public class ArretViewModel : INotifyPropertyChanged
    {

        public arrets Item
        {
            get;
            set;
        }

        public int NumeroTrain
        {
            get
            {
                return this.Item.NumeroTrain;
            }
            set
            {
                this.Item.NumeroTrain = value;
                OnPropertyChanged("NumeroTrain");
            }

        }

        public int IdGare
        {
            get
            {
                return this.Item.IdGare;
            }
            set
            {
                this.Item.IdGare = value;
                OnPropertyChanged("IdGare");
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

        public int IdArret
        {

            get
            {
                return this.Item.IdArret;
            }
            set
            {
                this.Item.IdArret = value;
                OnPropertyChanged("IdArret");
            }

        }
        public bool IsTerminus
        {

            get
            {
                return this.Item.IsTerminus;
            }
            set
            {
                this.Item.IsTerminus = value;
                OnPropertyChanged("IsTerminus");
            }

        }

        public int IdTrajet
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

        public int IdVille
        {

            get
            {
                return this.Item.IdVille;
            }
            set
            {
                this.Item.IdVille = value;
                OnPropertyChanged("IdVille");
            }

        }

        public ville Villes{
            get{
                return this.Item.ville;
            }
        }

        public ArretViewModel()
        {
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
