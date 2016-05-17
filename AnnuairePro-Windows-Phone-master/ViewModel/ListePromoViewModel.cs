using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;
using AnnuairePro.ViewModel.Interface;
using AnnuairePro.SQLLite;
using AnnuairePro.ViewModel;
using System.Windows.Input;
using AnnuairePro.Navigation;
using AnnuairePro.View;
using AnnuairePro.Helper;
using System.Collections.ObjectModel;

namespace AnnuairePro.ViewModel
{
    public class ListePromoViewModel : ViewModelBase, IListePromoView
    {
        #region Interface Properties/Accessors

        private ObservableCollection<Promo> _listPromo;
        public ObservableCollection<Promo> ListPromo
        {
            get { return _listPromo; }
            set { NotifyPropertyChanged(ref _listPromo, value); }
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

        public ListePromoViewModel()
        {
            this._navigationService = new NavigationService();
            DataBaseManagement.CreateDatabase();
            ListPromo = DataBaseManagement.LoadDataPromo();
            this.AjouterPromoCommand = new RelayCommand(AjouterPromo);
            this.GoToNextPageCommand = new RelayCommandWithParam<string>(GoToNextPage);
        }

        public ICommand AjouterPromoCommand { get; private set; }
        public ICommand GoToNextPageCommand { get; private set; }

        #region private Methods

        private void AjouterPromo()
        {
            DataBaseManagement.InsertDataPromo(NomPromo);
            NomPromo = "";
            ListPromo = DataBaseManagement.LoadDataPromo();
        }

        public void GoToNextPage(string nomPromo)
        {
            _navigationService.Navigate(typeof(ListePersonneView), nomPromo);
        }

        #endregion
    }


}

