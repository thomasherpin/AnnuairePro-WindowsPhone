using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuairePro.Model;

namespace AnnuairePro.Model
{
    public class MessageModel
    {
        public List<Personne> Destinataire { get; set; }

        public string Message { get; set; }

        public string Objet { get; set; }
    }
}
