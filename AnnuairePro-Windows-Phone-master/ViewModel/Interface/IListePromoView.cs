using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;
using System.Collections.ObjectModel;

namespace AnnuairePro.ViewModel.Interface
{
    public interface IListePromoView
    {
         ObservableCollection<Promo> ListPromo { get; set; }
    }
}
