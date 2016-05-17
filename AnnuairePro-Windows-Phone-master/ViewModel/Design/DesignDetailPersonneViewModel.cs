using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;
using AnnuairePro.ViewModel.Interface;

namespace AnnuairePro.ViewModel.Design
{
    public class DesignDetailPersonneViewModel : IDetailPersonneView
    {
        public Personne Perso
        {
            get
            {
                return new Personne
                {
                    Nom = "Appriou",
                    Prenom = "Ludovic",
                    Mail = "ludovic.appriou@epsi.fr",
                    Photo = "/Assets/Image/Ludovic-Appriou.jpg",
                    DateNaissance = new DateTime(1993, 01, 24)

                };
            }
            set { }
        }
    }
}
