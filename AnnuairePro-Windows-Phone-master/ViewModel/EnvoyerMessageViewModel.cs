using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.ViewModel.Interface;
using AnnuairePro.Model;
using AnnuairePro.Navigation;
using System.Windows.Input;
using AnnuairePro.View;




namespace AnnuairePro.ViewModel
{
    public class EnvoyerMessageViewModel: ViewModelBase, IEnvoyerMessageView
    {
        #region Interface Properties/Accessors


        private MessageModel _message;
        public MessageModel Mess
        {
            get { return _message; }
            set { NotifyPropertyChanged(ref _message, value); }
        }
        
        #endregion

        #region Private properties

        private INavigationService _navigationService;

        #endregion

        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public EnvoyerMessageViewModel()
        {
            Mess = new MessageModel();
            //La methode permet de remplir la liste de destinataire vu que le relaycommand ne marche pas
            AjouterTest();
            this._navigationService = new NavigationService();
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.AnnulerCommand = new RelayCommand(Annuler);

        }
        // Constructeur appelé normalement par le relaycommand
        public EnvoyerMessageViewModel(List<Personne> destinataires)
        {
            Mess = new MessageModel();
            Mess.Destinataire = destinataires;
            this._navigationService = new NavigationService();
            this.EnvoyerMessageCommand = new RelayCommand(EnvoyerMessage);
            this.AnnulerCommand = new RelayCommand(Annuler);

        }


        public ICommand EnvoyerMessageCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }

        #region private Methods

        private void EnvoyerMessage()
        {
            ComposeEmail();
            _navigationService.GoBack();
            

        }

        private void Annuler()
        {
            _navigationService.GoBack();
        }


        private async void ComposeEmail()
        {
            List<Personne> destinataires = Mess.Destinataire;
            for(int i = 0; i< Mess.Destinataire.Count; i++)
            {
                var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
                emailMessage.Subject = Mess.Objet;
                emailMessage.Body = Mess.Message;
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(Mess.Destinataire[i].Mail);
                emailMessage.To.Add(emailRecipient);
                await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
            }
        }

        public void AjouterTest()
        {
            Personne Perso = new Personne();
            Perso.Nom = "Appriou";
            Perso.Prenom = "Ludovic";
            Perso.Mail = "ludovic.appriou@epsi.fr";
            Perso.Photo = "/Assets/Image/Ludovic-Appriou.jpg";
            Perso.DateNaissance = new DateTime(1993, 01, 24);

            Mess.Destinataire = new List<Personne> { Perso};
        }

        #endregion
    }
}
