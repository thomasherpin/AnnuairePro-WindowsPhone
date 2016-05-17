using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.ViewModel.Interface;
using AnnuairePro.Model;
using AnnuairePro.Navigation;
using AnnuairePro.SQLLite;
using AnnuairePro.View;
using System.Windows.Input;

namespace AnnuairePro.ViewModel
{
    public class DetailPersonneViewModel : ViewModelBase, IDetailPersonneView
    {
        #region Interface Properties/Accessors


        private Personne _perso;
        public Personne Perso
        {
            get { return _perso; }
            set { NotifyPropertyChanged(ref _perso, value); }
        }

        private string _nomPersonneSelectionner;
        public string NomPersonneSelectionner
        {
            get { return _nomPersonneSelectionner; }
            set { NotifyPropertyChanged(ref _nomPersonneSelectionner, value); }
        }


        #region Private properties

        private INavigationService _navigationService;

        #endregion

        #endregion

        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme
        public DetailPersonneViewModel()
        {
            string nom = "Appriou";
            this._navigationService = new NavigationService();
            NomPersonneSelectionner = nom;
            Perso = DataBaseManagement.LoadDataPersonne(nom);
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.RetourCommand = new RelayCommand(Retour);

        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel
        public DetailPersonneViewModel(string nomPersonne)
        {
            string nom = nomPersonne;
            this._navigationService = new NavigationService();
            NomPersonneSelectionner = nom;
            Perso = DataBaseManagement.LoadDataPersonne(nom);
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.RetourCommand = new RelayCommand(Retour);

        }


        public ICommand EnvoyerMessageCommand { get; private set; }
        public ICommand RetourCommand { get; private set; }

        #region private Methods

        private void EnvoyerMessage()
        {
            List<Personne> personne = new List<Personne>();
            personne.Add(Perso);

            _navigationService.Navigate(typeof(EnvoyerMessageView), personne);
        }

        private void Retour()
        {

            _navigationService.GoBack();
        }
        #endregion
    }
}
