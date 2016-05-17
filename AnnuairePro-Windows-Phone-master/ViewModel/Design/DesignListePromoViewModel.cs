using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;
using AnnuairePro.ViewModel.Interface;
using System.Collections.ObjectModel;

namespace AnnuairePro.ViewModel.Design
{
    public class DesignListePromoViewModel : IListePromoView
    {
        public ObservableCollection<Promo> ListPromo
        {
            get
            {
                return new ObservableCollection<Promo>
                {
                    new Promo
                    {
                        Nom = "B1",
                    },
                    new Promo
                    {
                        Nom = "B2",
                    },
                    new Promo
                    {
                        Nom = "B3",
                    },
                    new Promo
                    {
                        Nom = "I4",
                    }
                };
            }
            set { }
        }
    }
}
