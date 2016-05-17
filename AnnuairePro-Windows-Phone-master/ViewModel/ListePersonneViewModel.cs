using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;
using AnnuairePro.SQLLite;
using System.Windows.Input;
using AnnuairePro.View;
using AnnuairePro.Navigation;
using AnnuairePro.ViewModel.Interface;


namespace AnnuairePro.ViewModel
{
    public class ListePersonneViewModel: ViewModelBase, IListePersonneView
    {
        #region Interface Properties/Accessors


        private List<Personne> _listPersonne;
        public List<Personne> ListPersonne
        {
            get { return _listPersonne; }
            set { NotifyPropertyChanged(ref _listPersonne, value); }
        }

        // Variable pour ajouter une promo dans l'application
        private string _nomPromo;
        public string NomPromo
        {
            get { return _nomPromo; }
            set { NotifyPropertyChanged(ref _nomPromo, value); }
        }
        #endregion



        #region Private properties

        private INavigationService _navigationService;

        #endregion

        public ListePersonneViewModel()
        {
            // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme
            NomPromo = "Test";
            this._navigationService = new NavigationService();
            ListPersonne = DataBaseManagement.LoadDataListePersonne(NomPromo);
            this.AjouterPersonneCommand = new RelayCommand(AjouterPersonne);
            this.SelectionnerPersonneCommand = new RelayCommandWithParam<string>(SelectionnerPersonne);
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.RetourCommand = new RelayCommand(Retour);
        }

        // Constructeur appelé normalement par le relaycommand de ListePromoViewModel

        public ListePersonneViewModel(string nom)
        {

            NomPromo = nom;
            this._navigationService = new NavigationService();
            ListPersonne = DataBaseManagement.LoadDataListePersonne(NomPromo);
            this.AjouterPersonneCommand = new RelayCommand(AjouterPersonne);
            this.SelectionnerPersonneCommand = new RelayCommandWithParam<string>(SelectionnerPersonne);
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.RetourCommand = new RelayCommand(Retour);

        }

        public ICommand AjouterPersonneCommand { get; private set; }
        public ICommand SelectionnerPersonneCommand { get; private set; }
        public ICommand EnvoyerMessageCommand { get; private set; }
        public ICommand RetourCommand { get; private set; }

        #region private Methods

        private void SelectionnerPersonne(string nom)
        {
            _navigationService.Navigate(typeof(DetailPersonneView), nom);
        }

        private void AjouterPersonne()
        {
            _navigationService.Navigate(typeof(AjouterPersonneView), NomPromo);
        }

        private void EnvoyerMessage()
        {
            _navigationService.Navigate(typeof(EnvoyerMessageView), ListPersonne);

        }

        private void Retour()
        {
            _navigationService.Navigate(typeof(ListePromoView));

        }
        #endregion
    }
}
