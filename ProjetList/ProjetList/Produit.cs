using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetList
{
    class Produit
    {
        public string nom { get; set; }
        public decimal prix { get; set; }

        public Produit() { }
        public Produit(string nom, decimal prix)
        {
            this.nom = nom;
            this.prix = prix;
        }

        public void Afficher()
        {
            Console.WriteLine("- " + nom + " : ");
            Console.WriteLine("    - Prix : " + prix + "€");
            return;
        }


        public void Modifier()
        {
            try
            {
                string champNom = String.Empty;
                string stringChampPrix = String.Empty;
                decimal champPrix = 0;

                //Ici on demande à l'utilisateur de remplir les champs

                //Vérification du Nom
                if (String.IsNullOrWhiteSpace(champNom))
                    throw new Exception("Le nom ne peut pas être vide.");

                else if (!CheckOnlyLetters(champNom))
                    throw new Exception("Le nom ne peut pas contenir de caractère spécial");

                //Vérification du Prix
                else if (!decimal.TryParse(stringChampPrix, out champPrix))
                    throw new Exception("Le prix rentré n'est pas valide");

                else
                {
                    champPrix = decimal.Parse(stringChampPrix);

                    if (champPrix <= 0)
                        throw new Exception("Le prix ne peut pas être de 0 ou moins.");
                }
                
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Modifier();
            }
        }

        public bool CheckOnlyLetters(string nom)
        {
            Regex regex = new Regex("[a-zA-Z]+");
            return regex.IsMatch(nom);
        }
    }
}
