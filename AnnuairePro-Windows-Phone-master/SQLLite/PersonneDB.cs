using SQLite;
using System;

namespace AnnuairePro.SQLLite
{
    [Table("Personne")]
    public class PersonneDB
    {

        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Annee { get; set; }
        public int Mois  { get; set; }
        public int Jour { get; set; }
        public string Mail { get; set; }
        public string Photo { get; set; }
        public string NomPromo { get; set; }
    }
}
