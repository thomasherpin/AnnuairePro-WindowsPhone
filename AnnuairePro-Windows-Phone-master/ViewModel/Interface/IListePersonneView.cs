using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;

namespace AnnuairePro.ViewModel.Interface
{
    public interface IListePersonneView
    {
        string NomPromo { get; set; }
        List<Personne> ListPersonne { get; set; }
    }
}
