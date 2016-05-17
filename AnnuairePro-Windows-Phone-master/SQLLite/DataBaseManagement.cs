using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using AnnuairePro.View;
using AnnuairePro.ViewModel;
using AnnuairePro.Model;
using System.Collections.ObjectModel;
using System;

namespace AnnuairePro.SQLLite
{
    public class DataBaseManagement
    {
        private static SQLiteConnection ConnectionDb()
        {
            var conn = new SQLite.SQLiteConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "annuairePro.db"), true);
            return conn;
        }



        public static void CreateDatabase()
        {
            ConnectionDb().CreateTable<PersonneDB>();
            ConnectionDb().CreateTable<PromoDB>();
        }

        public static ObservableCollection<Promo> LoadDataPromo()
        {
            ObservableCollection<Promo> promos = new ObservableCollection<Promo>();
            var query = ConnectionDb().Table<PromoDB>().OrderBy(r => r.Nom);
            List<PromoDB> result = query.ToList();


            foreach (var promo in result)
            {
                promos.Add(new Promo { Nom = promo.Nom });
            }

            return promos;
        }

        public static List<Personne> LoadDataListePersonne(string nom)
        {
            List<Personne> personnes = new List<Personne>();
            var query = ConnectionDb().Table<PersonneDB>().Where(r => r.NomPromo == nom).OrderBy(o => o.Nom);
            List<PersonneDB> result = query.ToList();


            foreach (var personne in result)
            {
                personnes.Add(new Personne { Nom = personne.Nom, Prenom = personne.Prenom, Mail = personne.Mail, Photo = personne.Photo });
            }

            return personnes;
        }


        public static void InsertDataPromo(string _nom)
        {
            var newpromo = new PromoDB
            {
                Nom = _nom
            };
            ConnectionDb().Insert(newpromo);
        }

        public static void InsertDataPersonne(Personne personne, string nomPromo)
        {
            var newPersonne = new PersonneDB
            {
                Nom = personne.Nom,
                Prenom = personne.Prenom,
                Mail = personne.Mail,
                Photo = personne.Photo,
                Annee = personne.DateNaissance.Year,
                Mois = personne.DateNaissance.Month,
                Jour = personne.DateNaissance.Day,
                NomPromo = nomPromo

                
            };
            ConnectionDb().Insert(newPersonne);
        }

        public static Personne LoadDataPersonne(string nom)
        {
            Personne perso = new Personne();
            var query = ConnectionDb().Table<PersonneDB>().Where(r => r.Nom == nom);
            List<PersonneDB> result = query.ToList();
            perso.DateNaissance = new DateTime();

            perso.Nom = result[0].Nom;
            perso.Prenom = result[0].Prenom;
            perso.Photo = result[0].Photo;
            perso.Mail = result[0].Mail;
            perso.DateNaissance = new DateTime(result[0].Annee,result[0].Mois,result[0].Jour);
            perso.NomPromo = result[0].NomPromo;
            return perso;
        }
    }
}
