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
    public class AjouterPersonneViewModel : ViewModelBase, IAjouterPersonneView
    {
        #region Interface Properties/Accessors


        private Personne _personne;
        public Personne Perso
        {
            get { return _personne; }
            set { NotifyPropertyChanged(ref _personne, value); }
        }

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

        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public AjouterPersonneViewModel()
        {
            AjouterTest();
            
            NomPromo = "Test";
            this._navigationService = new NavigationService();
            this.AjouterPersonneCommand = new RelayCommand(AjouterPersonne);
            this.AnnulerCommand = new RelayCommand(Annuler);
        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel
        public AjouterPersonneViewModel(string nomPromo)
        {
            AjouterTest();

            NomPromo = nomPromo;
            this._navigationService = new NavigationService();
            this.AjouterPersonneCommand = new RelayCommand(AjouterPersonne);
            this.AnnulerCommand = new RelayCommand(Annuler);
        }
        public ICommand AjouterPersonneCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }

        #region private Methods

        private void SelectionnerPersonne(string Nom)
        {
            _navigationService.Navigate(typeof(DetailPersonneView), Nom);
        }

        private void AjouterPersonne()
        {
             
            DataBaseManagement.InsertDataPersonne(Perso, "Test");
            _navigationService.Navigate(typeof(ListePersonneView), NomPromo);
        }

        private void Annuler()
        {
            _navigationService.Navigate(typeof(ListePersonneView), NomPromo);
        }


        //Une methode qui permet d'avoir un formulaire pré remplis
        public void AjouterTest()
        {
            Perso = new Personne();
            Perso.Nom = "Appriou";
            Perso.Prenom = "Ludovic";
            Perso.Mail = "ludovic.appriou@epsi.fr";
            Perso.Photo = "/Assets/Image/Ludovic-Appriou.jpg";
            Perso.DateNaissance = new DateTime(1993, 01, 24);
        
        }


        #endregion
    }
}

