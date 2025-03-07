using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RevisionEmploye
{
    public class Employe
    {
        private string _matricule;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private decimal _salaireAnnuel;
        private DateTime _entreeEnFonction;
        private DateTime _entreeFonctionEXAMPLE;

        public string Matricule
        {
            get => _matricule;
            set
            {
                if (value.Length == 7 || int.TryParse(value, out _))
                {
                     _matricule = value;
                }
                else 
                { 
                    throw new FormatException("Le matricule doit être composé de sept chiffres.");
                }  
                
            }
        }

        public string Nom
        {
            get => _nom;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom ne peut pas être vide.");
                _nom = value.Trim();
            }
        }

        public string Prenom
        {
            get => _prenom;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le prénom ne peut pas être vide.");
                _prenom = value.Trim();
            }
        }

        public DateTime DateNaissance
        {
            get => _dateNaissance;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("La date de naissance ne peut pas être dans le futur.");
                }
                else
                {
                    _dateNaissance = value;
                }
            }
        }

        public double SalaireAnnuel
        {
            get => (double)_salaireAnnuel;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Le salaire annuel ne peut pas être négatif.");
                _salaireAnnuel = (decimal)Math.Round(value, 2);
            }
        }

        public DateTime EntreeEnFonction
        {
            get => _entreeEnFonction;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("La date d'entrée ne peut pas être dans le futur.");
                _entreeEnFonction = value;
            }
        }


        public Employe(string matricule, string nom, string prenom, DateTime dn, double salaire, DateTime ef) 
        {
            Matricule = matricule;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dn;
            SalaireAnnuel = salaire;
            EntreeEnFonction = ef;
        }

        public int Age() 
        {
            DateTime dateActuelle = DateTime.Now;
            TimeSpan age = dateActuelle - DateNaissance;

            int total= (int)Math.Truncate(age.TotalDays / 365.025); 

            return total;
        }

        public int Anciennete() 
        {
            int anciennete = DateTime.Now.Year - EntreeEnFonction.Year;
            if (DateTime.Now.DayOfYear < EntreeEnFonction.DayOfYear)
                anciennete--; // Réduire l'ancienneté si l'anniversaire d'entrée n'est pas encore passé cette année
            return anciennete;
        }

        public bool DroitStationnement() 
        {
            return Age() > 40 || Anciennete() > 20 ;
           
        }

        public override string ToString()
        {
            return $"*** Données des employés *** \n" +
                    $"Matricule: {Matricule}\n" +
                    $"Nom: {Nom}\n" +
                    $"Prénom: {Prenom} \n" +
                    $"Date de naissance: {DateNaissance.ToString("yyyy/MM/dd")} \n" +
                    $"Salaire annuel: {SalaireAnnuel:C} \n" +
                    $"Date d'entrée en fonction: {EntreeEnFonction.ToString("yyyy/MM/dd")} \n" +
                    $"Âge: {Age()} ans \n" +
                    $"Anciennte: {Anciennete()} ans \n" +
                    $"Droit au stationnement gratuit: {(DroitStationnement() ? "OUI" : "NON")}\n";
        }
    }
}
