using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.ViewModel.Interface;
using AnnuairePro.Model;

namespace AnnuairePro.ViewModel.Design
{
    public class DesignListePersonneViewModel : IListePersonneView
    {

        

        public List<Personne> ListPersonne
        {
            get
            {
                return new List<Personne>
                {
                    new Personne
                    {
                        Nom = "Herpin",
                        Prenom = "Thomas",
                        Mail = "thomas.herpin@epsi.fr",
                        Photo = "/Assets/Images/Thomas-Herpin.jpg",
                        DateNaissance = new DateTime(1996,03,20),


                    },
                    new Personne
                    {
                        Nom = "Appriou",
                        Prenom = "Ludovic",
                        Mail = "ludovic.appriou@epsi.fr",
                        Photo = "/Assets/Images/Ludovic-Appriou.jpg",
                        DateNaissance = new DateTime(1996,03,20),

                    },
                };
            }
            set { }
        }

        public string NomPromo
        {
            get
            {
                return "Test";
            }

            set
            {
            }
        }
    }
}
